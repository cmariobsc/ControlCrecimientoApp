'use strict';
proyectoApp.controller('childrenController',
    ['$ekathuwa', 'validaIdentificacionService', 'childrenService', '$filter', 'NgTableParams', '$scope', '$rootScope', 'AppConfig', 'catalogoService',
        function ($ekathuwa, validaIdentificacionService, childrenService, $filter, NgTableParams, $scope, $rootScope, appConfig, catalogoService) {

            $scope.message = "";

            $scope.validaIdentificacion = validaIdentificacionService;

            $scope.listNacionalidad = catalogoService.catalogoNacionalidad();

            var dateNow = new Date();
            var year = dateNow.getFullYear();
            var month = dateNow.getMonth();
            var day = dateNow.getDate();
            var dateMin = new Date(year - 12, month - 12, day + 1);
            var dateAgo = new Date(year - 1, month, day);

            //Configuraciones para el popup fecha
            $scope.dateOptions = {
                minDate: dateMin,
                maxDate: dateAgo
            };

            $scope.popup = {
                opened: false
            };

            $scope.abrirCalendario = function () {
                $scope.popup.opened = true;
            };

            $scope.datoChildren = {};

            $scope.datoChildren.fechaNacimiento = dateAgo;
            ////////////////////////////////////////////////

            $scope.calculateAge = function calculateAge(birthday) {
                var ageDifMs = Date.now() - birthday.getTime();
                var ageDate = new Date(ageDifMs);
                $scope.datoChildren.edad = Math.abs(ageDate.getUTCFullYear() - 1970);
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
                        $scope.datoChildren.edad = children.data.edad;
                        $scope.datoChildren.talla = children.data.talla;
                        $scope.datoChildren.peso = children.data.peso;
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
                    Edad: $scope.datoChildren.edad,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
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
                    Edad: $scope.datoChildren.edad,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
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
                childrenService.deleteChildren(idChildren).then(function (response) {
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

            $scope.cerrar = function () {
                $scope.getListChildren();
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
        }]);