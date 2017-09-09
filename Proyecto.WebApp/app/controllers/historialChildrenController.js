'use strict';
proyectoApp.controller('historialChildrenController',
    ['$ekathuwa', 'childrenService', '$filter', 'NgTableParams', '$scope', '$rootScope', 'AppConfig', 'catalogoService',
        function ($ekathuwa, childrenService, $filter, NgTableParams, $scope, $rootScope, appConfig, catalogoService) {

            $scope.listNacionalidad = catalogoService.catalogoNacionalidad();
            $scope.listSexo = catalogoService.catalogoSexo();

            $scope.datos = [];

            $scope.getListChildren = function () {
                childrenService.getListChildren($rootScope.idRepresentante)
                    .then(function (response) {
                        $scope.children_message = response.mensajeRetorno;
                        var data = response.data;

                        $scope.childrenTable = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: data
                            });

                    }, function (error) { });
            }

            $scope.getListChildren();

            $scope.consultar = function (idChildren) {
                childrenService.getListHistorialChildren(idChildren)
                    .then(function (response) {
                        $scope.history_message = response.mensajeRetorno;
                        var data = response.data;
                        $scope.nombreCompleto = data[0].nombreCompleto;
                        $scope.idSexo = data[0].idSexo;

                        $scope.historyTable = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: data
                            });

                    }, function (error) { });
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

            $scope.ModalMensaje = function (mensaje) {
                $scope.header = "Historial de Crecimientos";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalAlertaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/alerta.html"
                });
            }
        }]);