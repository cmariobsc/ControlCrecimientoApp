'use strict';
proyectoApp.controller('appController',
    ['$location', '$scope', 'authService', '$ekathuwa', 'omsInfoService',
        function ($location, $scope, authService, $ekathuwa, omsInfoService) {

            $scope.isLoggedIn = authService.authentication.isAuth;

            if ($scope.isLoggedIn) {

                $location.path('/home');

            } else {
                $location.path('/app');
                $scope.appActive = true;
            }

            $scope.indicador = 0;

            $scope.links = [
                { src: "content/images/banners/banner1.png", alt: ""},
                { src: "content/images/banners/banner2.jpg", alt: ""},
                { src: "content/images/banners/banner3.jpg", alt: ""},
                { src: "content/images/banners/banner4.jpg", alt: ""},
                { src: "content/images/banners/banner5.jpg", alt: ""},
                { src: "content/images/banners/banner6.jpg", alt: "" },
                { src: "content/images/banners/banner7.jpg", alt: "" },
                { src: "content/images/banners/banner8.jpg", alt: "" },
                { src: "content/images/banners/banner9.jpg", alt: "" },
                { src: "content/images/banners/banner10.jpg", alt: "" },
            ]

            $scope.listSexo = [
                {
                    idSexo: '1',
                    descripcion: 'Masculino'
                },
                {
                    idSexo: '2',
                    descripcion: 'Femenino'
                },
            ]

            var now = new Date();
            var yearNow = now.getYear();
            var monthNow = now.getMonth();
            var dateNow = now.getDate();
            var dateMin = new Date(yearNow - 13, monthNow + 1, dateNow);

            //Configuraciones para el popup fecha
            $scope.dateOptions = {
                minDate: dateMin
            };

            $scope.popup = {
                opened: false
            };

            $scope.abrirCalendarioFN = function () {
                $scope.popup.openedFN = true;
            };

            $scope.datoChildren = {};

            $scope.datoChildren.fechaNacimiento = now;
            ////////////////////////////////////////////////

            $scope.calculateAge = function calculateAge(birthday) {

                var dob = new Date(birthday);
                var yearDob = dob.getYear();
                var monthDob = dob.getMonth();
                var dateDob = dob.getDate();
                var age = {};
                var ageString = "";
                var yearString = "";
                var monthString = "";
                var dayString = "";

                var yearAge = yearNow - yearDob;

                if (monthNow >= monthDob)
                    var monthAge = monthNow - monthDob;
                else {
                    yearAge--;
                    var monthAge = 12 + monthNow - monthDob;
                }

                if (dateNow >= dateDob)
                    var dateAge = dateNow - dateDob;
                else {
                    monthAge--;
                    var dateAge = 31 + dateNow - dateDob;

                    if (monthAge < 0) {
                        monthAge = 11;
                        yearAge--;
                    }
                }

                age = {
                    years: yearAge,
                    months: monthAge,
                    days: dateAge
                };

                $scope.datoChildren.edadAnios = age.years;
                $scope.datoChildren.edadMeses = age.months;
                $scope.datoChildren.edadTotalMeses = (age.years * 12) + age.months;
            }

            $scope.calculateAge($scope.datoChildren.fechaNacimiento);

            $scope.calculaIMC = function () {
                var alturaCuadrado = Math.pow($scope.datoChildren.talla / 100, 2);
                var imc = $scope.datoChildren.peso / alturaCuadrado;
                $scope.datoChildren.imc = roundToTwo(imc);

                /*Calculo descripcion IMC*/
                if (imc < 16) {
                    $scope.datoChildren.detalleIMC = "Delgadez Severa";
                }
                else if (imc < 17) {
                    $scope.datoChildren.detalleIMC = "Delgadez Moderada";
                }
                else if (imc < 18.5) {
                    $scope.datoChildren.detalleIMC = "Delgadez Aceptable";
                }
                else if (imc < 25) {
                    $scope.datoChildren.detalleIMC = "Peso Normal";
                }
                else if (imc < 30) {
                    $scope.datoChildren.detalleIMC = "Sobrepeso";
                }
                else if (imc < 35) {
                    $scope.datoChildren.detalleIMC = "Obeso: Tipo I";
                }
                else if (imc < 40) {
                    $scope.datoChildren.detalleIMC = "Obeso: Tipo II";
                }
                else if (imc >= 40) {
                    $scope.datoChildren.detalleIMC = "Obeso: Tipo III";
                }
            }

            $scope.cargarGrafica = function (indicador) {
                $scope.listChildren = [
                    {
                        edadTotalMeses: $scope.datoChildren.edadTotalMeses,
                        imc: $scope.datoChildren.imc
                    },
                    {
                        edadTotalMeses: $scope.datoChildren.edadTotalMeses,
                        imc: $scope.datoChildren.imc
                    }
                ]

                omsInfoService.getListIMCxEdad($scope.datoChildren.sexo)
                    .then(function (response) {
                        var data = response.data;
                        $scope.indicatorTitle = 'Masa Corporal del Niño'
                        $scope.chartTitle = response.mensajeRetorno;
                        obtenerParametro(data);
                        $scope.omsBuildChart(indicador);
                        $scope.indicador = indicador;
                    });
            }
            
            $scope.ayudaIMC = function () {
                $scope.ModalAyuda("Índice Masa Corporal (IMC)",
                    "Clasificación según la Organización Mundial de la Salud:",
                    "content/images/imcTabla.JPG"
                );
            }

            $scope.ModalAyuda = function (header, body, imageUrl) {
                $scope.header = header;
                $scope.body = body;
                $scope.imageUrl = imageUrl;
                $ekathuwa.modal({
                    id: "ModalAyudaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/ayuda.html"
                });
            }

            function roundToTwo(num) {
                return +(Math.round(num + "e+2") + "e-2");
            }

            var obtenerParametro = function (data) {
                $scope.meses = [];
                $scope.sD3neg = [];
                $scope.sD2neg = [];
                $scope.sD1neg = [];
                $scope.sD0 = [];
                $scope.sD1 = [];
                $scope.sD2 = [];
                $scope.sD3 = [];

                angular.forEach(data, function (value, key) {
                    if (key < $scope.datoChildren.edadTotalMeses + 4) {
                        $scope.meses.push(value.meses);
                        $scope.sD3neg.push(value.sD3neg);
                        $scope.sD2neg.push(value.sD2neg);
                        $scope.sD1neg.push(value.sD1neg);
                        $scope.sD0.push(value.sD0);
                        $scope.sD1.push(value.sD1);
                        $scope.sD2.push(value.sD2);
                        $scope.sD3.push(value.sD3);
                    }
                });
            }
        }
    ]);