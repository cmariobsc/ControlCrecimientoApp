'use strict';
proyectoApp.controller('datoRepresentanteController',
    ['$location', '$http', '$q', '$ekathuwa', 'validaIdentificacionService', '$filter', 'localStorageService', '$scope', '$rootScope', '$route', 'AppConfig',
        function ($location, $http, $q, $ekathuwa, validaIdentificacionService, $filter, localStorageService, $scope, $rootScope, $route, appConfig) {

            $scope.message = "";

            $scope.listParentesco = [{
                codigo: "1",
                descripcion: 'Madre'
            }, {
                codigo: "2",
                descripcion: 'Padre'
            },
            {
                codigo: "3",
                descripcion: 'Tío'
            }];

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