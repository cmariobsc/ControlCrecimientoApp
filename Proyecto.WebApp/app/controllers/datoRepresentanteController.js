'use strict';
proyectoApp.controller('datoRepresentanteController',
    ['$location', '$http', '$q', '$ekathuwa', 'validaIdentificacionService', '$filter', 'localStorageService', '$scope', '$rootScope', '$route', 'AppConfig', 'catalogoService',
        function ($location, $http, $q, $ekathuwa, validaIdentificacionService, $filter, localStorageService, $scope, $rootScope, $route, appConfig, catalogoService) {

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

        }]);