'use strict';
proyectoApp.factory('representanteService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
        function ($http, $q, localStorageService, appConfig) {

            var representanteServiceFactory = {}

            var serviceUrl = appConfig.apiUrl;

            var _getRepresentante = function (idUsuario) {
                var url = serviceUrl + '/representante/get';
                var deferred = $q.defer();

                $http({
                    method: 'POST',
                    url: url,
                    crossDomain: true,
                    cache: false,
                    params: { idUsuario: idUsuario }
                }).then(function (response) {
                    deferred.resolve(response);
                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            };

            var _editRepresentante = function (representante) {

                var url = serviceUrl + '/representante/edit';
                var deferred = $q.defer();

                $http({
                    url: url,
                    method: 'POST',
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded; charset=utf-8"
                    },
                    data: representante,
                    dataType: 'json'

                }).then(function (response) {
                    deferred.resolve(response);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            };

            representanteServiceFactory.getRepresentante = _getRepresentante;
            representanteServiceFactory.editRepresentante = _editRepresentante;

            return representanteServiceFactory;
        }
    ]);