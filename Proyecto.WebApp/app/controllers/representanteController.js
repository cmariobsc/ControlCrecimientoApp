'use strict';
proyectoApp.controller('representanteController',
    ['$location', '$http', '$q', '$ekathuwa', 'validaIdentificacionService', '$filter', 'localStorageService', '$scope', '$rootScope', '$route', 'AppConfig', 'catalogoService', 'representanteService',
        function ($location, $http, $q, $ekathuwa, validaIdentificacionService, $filter, localStorageService, $scope, $rootScope, $route, appConfig, catalogoService, representanteService) {

            $scope.message = "";

            $scope.listParentesco = catalogoService.catalogoParentesco();

            $scope.listNacionalidad = catalogoService.catalogoNacionalidad();

            $scope.listProvincia = catalogoService.catalogoProvincia();

            var ciudades = catalogoService.catalogoCiudad();
            $scope.cargaCiudad = function (idProvincia) {
                $scope.listCiudad = [];
                angular.forEach(ciudades, function (value, key) {
                    if (value.idProvincia == idProvincia) {
                        $scope.listCiudad.push(value);
                    }
                });
            }

            $scope.validaIdentificacion = validaIdentificacionService;

            //Configuraciones para el popup fecha
            $scope.dateOptions = {
                maxDate: new Date()
            };

            $scope.popup = {
                opened: false
            };

            $scope.abrirCalendario = function () {
                $scope.popup.opened = true;
            };

            $scope.datoRepresentante = {};

            $scope.datoRepresentante.fechaNacimiento = new Date();
            //////////////////////////////////////

            $scope.consultar = function () {
                representanteService.getRepresentante(1).then(function (response) {
                    if (response.data.codError === "000") {
                        console.log(response.data);
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.ModalMensaje = function (mensaje) {
                $scope.header = "Datos del Representante";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalAlertaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/alerta.html"
                });
            }

            $scope.consultar();
        }]);