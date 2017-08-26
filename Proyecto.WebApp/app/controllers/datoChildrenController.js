'use strict';
proyectoApp.controller('datoChildrenController',
    ['$location', '$http', '$q', '$ekathuwa', 'validaIdentificacionService', 'childrenService', '$filter', 'NgTableParams', 'localStorageService', '$scope', '$rootScope', '$route', 'AppConfig', 'catalogoService',
        function ($location, $http, $q, $ekathuwa, validaIdentificacionService, childrenService, $filter, NgTableParams, localStorageService, $scope, $rootScope, $route, appConfig, catalogoService) {

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

            $scope.getChildren = function () {
                childrenService.getChildren(1)
                    .then(function (response) {
                        $scope.children_message = response.message;
                        var data = response.data;
                        $scope.tableParams = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: data
                            });
                    }, function (error) { });
            }

            $scope.getChildren();

            $scope.guardar = function () {
                $scope.datos.push({
                    Identificacion: $scope.datoChildren.identificacion,
                    DatoNacionalidad: $scope.datoChildren.nacionalidad,
                    Nombres: $scope.datoChildren.nombres,
                    Apellidos: $scope.datoChildren.apellidos,
                    FechaNacimiento: $filter('date')($scope.datoChildren.fechaNacimiento, 'dd/MM/yyyy'),
                    Edad: $scope.datoChildren.edad,
                    Talla: $scope.datoChildren.talla,
                    Peso: $scope.datoChildren.peso,
                });


                $scope.tableParams = new NgTableParams({
                    page: 1,
                    count: 10
                },
                    {
                        dataset: $scope.datos
                    });
            };

            
        }]);