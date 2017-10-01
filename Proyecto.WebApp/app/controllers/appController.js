'use strict';
proyectoApp.controller('appController',
    ['$location', '$scope', 'authService', '$ekathuwa',
        function ($location, $scope, authService, $ekathuwa) {

            $scope.isLoggedIn = authService.authentication.isAuth;

            if ($scope.isLoggedIn) {

                $location.path('/home');

            } else {
                $location.path('/app');
                $scope.appActive = true;
            }

            $scope.links = [
                { src: "http://www.conceptcarz.com/images/Suzuki/suzuki-concept-kizashi-3-2008-01-800.jpg", alt: "", caption: "" },
                { src: "http://www.conceptcarz.com/images/Volvo/2009_Volvo_S60_Concept-Image-01-800.jpg", alt: "", caption: "" },
                { src: "http://www.sleepzone.ie/uploads/images/PanelImages800x400/TheBurren/General/sleepzone_hostels_burren_800x400_14.jpg", alt: "", caption: "" },
            ];

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
        }
    ]);