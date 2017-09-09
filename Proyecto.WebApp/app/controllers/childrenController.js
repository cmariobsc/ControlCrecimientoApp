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
                minDate: dateMin,
                maxDate: now
            };

            $scope.popup = {
                opened: false
            };

            $scope.abrirCalendario = function () {
                $scope.popup.opened = true;
            };

            $scope.datoChildren = {};

            $scope.datoChildren.fechaNacimiento = now;
            ////////////////////////////////////////////////

            $scope.calculateAge = function calculateAge(birthday) {

                var dateOfBirtday = new Date(birthday);

                var dobYear = dateOfBirtday.getFullYear();
                var dobMonth = dateOfBirtday.getMonth();
                var dobDay = dateOfBirtday.getDate();

                var ageyear = nowYear - dobYear;
                var agemonth = nowMonth - dobMonth;
                var ageday = nowDay - dobDay;

                if (agemonth < 0) {
                    ageyear--;
                    agemonth = (12 + agemonth);
                }

                if (nowDay < dobDay) {
                    agemonth--;
                    ageday = 30 + ageday;
                }

                $scope.datoChildren.edadAnios = ageyear;
                $scope.datoChildren.edadMeses = agemonth;
            }

            $scope.calculateAge($scope.datoChildren.fechaNacimiento);

            $scope.datos = [];

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
                        $scope.datoChildren.identificacion = children.data.identificacion;
                        $scope.datoChildren.nombres = children.data.nombres;
                        $scope.datoChildren.apellidos = children.data.apellidos;
                        $scope.datoChildren.fechaNacimiento = new Date(children.data.fechaNacimiento);
                        $scope.datoChildren.edadAnios = children.data.edadAnios;
                        $scope.datoChildren.edadMeses = children.data.edadMeses;
                        $scope.datoChildren.talla = children.data.talla;
                        $scope.datoChildren.peso = children.data.peso;
                        $scope.datoChildren.sexo = children.data.idSexo;
                        $scope.datoChildren.observaciones = children.data.observaciones;
                        $scope.fechaCreacion = children.data.fechaCreacion;
                        $scope.datoChildren.nacionalidad = children.data.idNacionalidad;

                        $scope.modificando = true;
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.guardar = function () {
                var children = $.param({
                    Identificacion: $scope.datoChildren.identificacion,
                    IdNacionalidad: $scope.datoChildren.nacionalidad,
                    Nombres: $scope.datoChildren.nombres,
                    Apellidos: $scope.datoChildren.apellidos,
                    FechaNacimiento: $filter('date')($scope.datoChildren.fechaNacimiento, 'yyyy/MM/dd'),
                    EdadAnios: $scope.datoChildren.edadAnios,
                    EdadMeses: $scope.datoChildren.edadMeses,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
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
                    Identificacion: $scope.datoChildren.identificacion,
                    Nombres: $scope.datoChildren.nombres,
                    Apellidos: $scope.datoChildren.apellidos,
                    FechaNacimiento: $filter('date')($scope.datoChildren.fechaNacimiento, 'yyyy/MM/dd'),
                    EdadAnios: $scope.datoChildren.edadAnios,
                    EdadMeses: $scope.datoChildren.edadMeses,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
                    IdSexo: $scope.datoChildren.sexo,
                    Observaciones: $scope.datoChildren.observaciones,
                    FechaCreacion: $scope.fechaCreacion,
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
                $scope.datoChildren.identificacion = "";
                $scope.datoChildren.nombres = "";
                $scope.datoChildren.apellidos = "";
                $scope.datoChildren.fechaNacimiento = now;
                $scope.datoChildren.edadAnios = "0";
                $scope.datoChildren.edadMeses = "0";
                $scope.datoChildren.talla = "";
                $scope.datoChildren.peso = "";
                $scope.datoChildren.sexo = "";
                $scope.datoChildren.observaciones = "";
                $scope.fechaCreacion = "";
                $scope.datoChildren.nacionalidad = "";
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