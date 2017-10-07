'use strict';
proyectoApp.controller('childrenController',
    ['$ekathuwa', 'validaIdentificacionService', 'childrenService', '$filter', 'NgTableParams', '$scope', '$rootScope', 'AppConfig', 'catalogoService',
        function ($ekathuwa, validaIdentificacionService, childrenService, $filter, NgTableParams, $scope, $rootScope, appConfig, catalogoService) {

            $scope.message = "";

            $scope.validaIdentificacion = validaIdentificacionService;

            $scope.listNacionalidad = catalogoService.catalogoNacionalidad();
            $scope.listSexo = catalogoService.catalogoSexo();

            var now = new Date();
            var nowYear = now.getFullYear();
            var nowMonth = now.getMonth();
            var nowDay = now.getDate();
            var dateMin = new Date(nowYear - 13, nowMonth + 1, nowDay);

            //Configuraciones para el popup fecha
            $scope.dateOptions = {
                minDate: dateMin
            };

            $scope.popup = {
                opened: false
            };

            $scope.abrirCalendarioFC = function () {
                $scope.popup.openedFC = true;
            };

            $scope.abrirCalendarioFN = function () {
                $scope.popup.openedFN = true;
            };

            $scope.datoChildren = {};

            $scope.datoChildren.fechaCreacion = now;
            $scope.datoChildren.fechaNacimiento = now;
            ////////////////////////////////////////////////

            $scope.ayudaIMC = function () {
                $scope.ModalAyuda("Índice Masa Corporal (IMC)",
                    "Clasificación según la Organización Mundial de la Salud:",
                    "content/images/imcTabla.JPG"
                );
            }

            $scope.ayudaPC = function () {
                $scope.ModalAyuda("Perímetro Cefálico (PC)",
                    "Es la medida en centímetros de la cabeza del niño:",
                    "content/images/pc.JPG"
                );
            }

            $scope.ayudaPMB = function () {
                $scope.ModalAyuda("Perímetro Medio Del Brazo (PMB)",
                    "Es la medida en centímetros del lado medio del brazo:",
                    "content/images/pmb.JPG"
                );
            }

            $scope.calculateAge = function calculateAge(birthday) {

                var now = new Date($scope.datoChildren.fechaCreacion);

                var yearNow = now.getYear();
                var monthNow = now.getMonth();
                var dateNow = now.getDate();

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

            function roundToTwo(num) {
                return +(Math.round(num + "e+2") + "e-2");
            }

            $scope.getListChildren = function () {
                childrenService.getListChildren($rootScope.idRepresentante)
                    .then(function (response) {
                        $scope.mensajeRetorno = response.mensajeRetorno;
                        var data = response.data;

                        $scope.tableParams = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: data
                            });

                        $scope.modificando = false;
                    }, function (error) { });
            }

            $scope.getListChildren();

            $scope.editar = function (idChildren) {
                childrenService.getChildren(idChildren).then(function (response) {
                    if (response.data.codError === "000") {
                        var children = response.data;
                        $scope.idChildren = children.data.idChildren;
                        $scope.datoChildren.fechaCreacion = new Date(children.data.fechaCreacion);
                        $scope.datoChildren.identificacion = children.data.identificacion;
                        $scope.datoChildren.nombres = children.data.nombres;
                        $scope.datoChildren.apellidos = children.data.apellidos;
                        $scope.datoChildren.fechaNacimiento = new Date(children.data.fechaNacimiento);
                        $scope.datoChildren.edadAnios = children.data.edadAnios;
                        $scope.datoChildren.edadMeses = children.data.edadMeses;
                        $scope.datoChildren.edadTotalMeses = children.data.edadTotalMeses;
                        $scope.datoChildren.talla = children.data.talla;
                        $scope.datoChildren.peso = children.data.peso;
                        $scope.datoChildren.imc = children.data.imc;
                        $scope.datoChildren.detalleIMC = children.data.detalleIMC;
                        $scope.datoChildren.perimCefalico = children.data.perimCefalico;
                        $scope.datoChildren.perimMedioBrazo = children.data.perimMedioBrazo;
                        $scope.datoChildren.sexo = children.data.idSexo;
                        $scope.datoChildren.observaciones = children.data.observaciones;
                        $scope.datoChildren.nacionalidad = children.data.idNacionalidad;

                        $scope.modificando = true;
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.guardar = function () {
                var children = $.param({
                    FechaCreacion: $filter('date')($scope.datoChildren.fechaCreacion, 'yyyy/MM/dd'),
                    Identificacion: $scope.datoChildren.identificacion,
                    IdNacionalidad: $scope.datoChildren.nacionalidad,
                    Nombres: $scope.datoChildren.nombres,
                    Apellidos: $scope.datoChildren.apellidos,
                    FechaNacimiento: $filter('date')($scope.datoChildren.fechaNacimiento, 'yyyy/MM/dd'),
                    EdadAnios: $scope.datoChildren.edadAnios,
                    EdadMeses: $scope.datoChildren.edadMeses,
                    EdadTotalMeses: $scope.datoChildren.edadTotalMeses,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
                    IMC: $scope.datoChildren.imc,
                    DetalleIMC: $scope.datoChildren.detalleIMC,
                    PerimCefalico: $scope.datoChildren.perimCefalico,
                    PerimMedioBrazo: $scope.datoChildren.perimMedioBrazo,
                    IdSexo: $scope.datoChildren.sexo,
                    Observaciones: $scope.datoChildren.observaciones,
                    IdRepresentante: $rootScope.idRepresentante
                });

                childrenService.saveChildren(children).then(function (response) {
                    if (response.data.codError === "000") {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            };

            $scope.actualizar = function () {
                var children = $.param({
                    IdChildren: $scope.idChildren,
                    FechaCreacion: $filter('date')($scope.datoChildren.fechaCreacion, 'yyyy/MM/dd'),
                    Identificacion: $scope.datoChildren.identificacion,
                    Nombres: $scope.datoChildren.nombres,
                    Apellidos: $scope.datoChildren.apellidos,
                    FechaNacimiento: $filter('date')($scope.datoChildren.fechaNacimiento, 'yyyy/MM/dd'),
                    EdadAnios: $scope.datoChildren.edadAnios,
                    EdadMeses: $scope.datoChildren.edadMeses,
                    EdadTotalMeses: $scope.datoChildren.edadTotalMeses,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
                    IMC: $scope.datoChildren.imc,
                    DetalleIMC: $scope.datoChildren.detalleIMC,
                    PerimCefalico: $scope.datoChildren.perimCefalico,
                    PerimMedioBrazo: $scope.datoChildren.perimMedioBrazo,
                    IdSexo: $scope.datoChildren.sexo,
                    Observaciones: $scope.datoChildren.observaciones,
                    IdNacionalidad: $scope.datoChildren.nacionalidad
                });

                childrenService.editChildren(children).then(function (response) {
                    if (response.data.codError === "000") {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            };

            $scope.eliminar = function (idChildren) {
                $scope.idChildrenDel = idChildren;
                $scope.ModalConfirmacion();
            }

            $scope.confirm = function () {
                childrenService.deleteChildren($scope.idChildrenDel).then(function (response) {
                    if (response.data.codError === "000") {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.obtenerNacionalidad = function (idNacionalidad) {
                var descripcion = "";
                angular.forEach($scope.listNacionalidad, function (value, key) {
                    if (value.idNacionalidad == idNacionalidad) {
                        descripcion = value.descripcion;
                    }
                });

                return descripcion;
            }

            $scope.obtenerSexo = function (idSexo) {
                var descripcion = "";
                angular.forEach($scope.listSexo, function (value, key) {
                    if (value.idSexo == idSexo) {
                        descripcion = value.descripcion;
                    }
                });

                return descripcion;
            }

            $scope.cerrar = function () {
                $scope.limpiar();
                $scope.getListChildren();
            }

            $scope.limpiar = function () {
                $scope.idChildren = "";
                $scope.datoChildren.fechaCreacion = now;
                $scope.datoChildren.identificacion = "";
                $scope.datoChildren.nombres = "";
                $scope.datoChildren.apellidos = "";
                $scope.datoChildren.fechaNacimiento = now;
                $scope.datoChildren.edadAnios = "0";
                $scope.datoChildren.edadMeses = "0";
                $scope.datoChildren.edadTotalMeses = "0";
                $scope.datoChildren.talla = "";
                $scope.datoChildren.peso = "";
                $scope.datoChildren.imc = "";
                $scope.datoChildren.detalleIMC = "";
                $scope.datoChildren.perimCefalico = "";
                $scope.datoChildren.perimMedioBrazo = "";
                $scope.datoChildren.sexo = "";
                $scope.datoChildren.observaciones = "";
                $scope.datoChildren.nacionalidad = "";
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

            $scope.ModalMensaje = function (mensaje) {
                $scope.header = "Datos del Niño";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalAlertaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/alerta.html"
                });
            }

            $scope.ModalConfirmacion = function () {
                $scope.header = "Datos del Niño";
                $scope.body = "¿Desea eliminar este registro?";
                $ekathuwa.modal({
                    id: "ModalConfirmacionId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/confirmacion.html"
                });
            }
        }]);