﻿'use strict';
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
                        $scope.datoChildren.edadAnos = children.data.edadAnos;
                        $scope.datoChildren.edadMeses = children.data.edadMeses;
                        $scope.datoChildren.talla = children.data.talla;
                        $scope.datoChildren.peso = children.data.peso;
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
                    EdadAnos: $scope.datoChildren.edadAnos,
                    EdadMeses: $scope.datoChildren.edadMeses,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
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
                    EdadAnos: $scope.datoChildren.edadAnos,
                    EdadMeses: $scope.datoChildren.edadMeses,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
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

            $scope.cerrar = function () {
                $scope.limpiar();
                $scope.getListChildren();
            }

            $scope.limpiar = function () {
                $scope.idChildren = "";
                $scope.datoChildren.identificacion = "";
                $scope.datoChildren.nombres = "";
                $scope.datoChildren.apellidos = "";
                $scope.datoChildren.fechaNacimiento = dateAgo;
                $scope.datoChildren.talla = "";
                $scope.datoChildren.peso = "";
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