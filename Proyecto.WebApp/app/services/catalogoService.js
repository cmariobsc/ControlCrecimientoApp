'use strict';
proyectoApp.factory('catalogoService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
        function ($http, $q, localStorageService, appConfig) {

            var catalogoServiceFactory = {}
            var serviceUrl = appConfig.apiUrl;

            var _getParentesco = function () {
                var url = serviceUrl + '/catalogo/listParentesco';
                var deferred = $q.defer();
                $http({
                    method: 'POST',
                    url: url,
                    crossDomain: true
                }).then(function (response) {
                    var result = response.data;
                    if (result.codError === "000") {
                        localStorageService.set('catalogoParentesco', result.data);
                    }
                    deferred.resolve(response);

                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            };

            var _getSexo = function () {
                var url = serviceUrl + '/catalogo/listSexo';
                var deferred = $q.defer();
                $http({
                    method: 'POST',
                    url: url,
                    crossDomain: true
                }).then(function (response) {
                    var result = response.data;
                    if (result.codError === "000") {
                        localStorageService.set('catalogoSexo', result.data);
                    }
                    deferred.resolve(response);

                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            };

            var _getNacionalidad = function () {
                var url = serviceUrl + '/catalogo/listNacionalidad';
                var deferred = $q.defer();
                $http({
                    method: 'POST',
                    url: url,
                    crossDomain: true
                }).then(function (response) {
                    var result = response.data;
                    if (result.codError === "000") {
                        localStorageService.set('catalogoNacionalidad', result.data);
                    }
                    deferred.resolve(response);

                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            };

            var _getProvincia = function () {
                var url = serviceUrl + '/catalogo/listProvincia';
                var deferred = $q.defer();
                $http({
                    method: 'POST',
                    url: url,
                    crossDomain: true
                }).then(function (response) {
                    var result = response.data;
                    if (result.codError === "000") {
                        localStorageService.set('catalogoProvincia', result.data);
                    }
                    deferred.resolve(response);

                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            };

            var _getCiudad = function () {
                var url = serviceUrl + '/catalogo/listCiudad';
                var deferred = $q.defer();
                $http({
                    method: 'POST',
                    url: url,
                    crossDomain: true
                }).then(function (response) {
                    var result = response.data;
                    if (result.codError === "000") {
                        localStorageService.set('catalogoCiudad', result.data);
                    }
                    deferred.resolve(response);

                }, function (error) {
                    deferred.reject(error);
                });

                return deferred.promise;
            };

            var _catalogoParentesco = function () {
                var storageCatalogo = localStorageService.get('catalogoParentesco');
                if (storageCatalogo == null) {
                    _getParentesco().then(function (response) {
                        storageCatalogo = localStorageService.get('catalogoParentesco');

                        return storageCatalogo;
                    });
                }

                return storageCatalogo;
            };

            var _catalogoSexo = function () {
                var storageCatalogo = localStorageService.get('catalogoSexo');
                if (storageCatalogo == null) {
                    _getSexo().then(function (response) {
                        storageCatalogo = localStorageService.get('catalogoSexo');

                        return storageCatalogo;
                    });
                }

                return storageCatalogo;
            };

            var _catalogoNacionalidad = function () {
                var storageCatalogo = localStorageService.get('catalogoNacionalidad');
                if (storageCatalogo == null) {
                    _getNacionalidad().then(function (response) {
                        storageCatalogo = localStorageService.get('catalogoNacionalidad');

                        return storageCatalogo;
                    });
                }

                return storageCatalogo;
            };

            var _catalogoProvincia = function () {
                var storageCatalogo = localStorageService.get('catalogoProvincia');
                if (storageCatalogo == null) {
                    _getProvincia().then(function (response) {
                        storageCatalogo = localStorageService.get('catalogoProvincia');

                        return storageCatalogo;
                    });
                }

                return storageCatalogo;
            };

            var _catalogoCiudad = function () {
                var storageCatalogo = localStorageService.get('catalogoCiudad');
                if (storageCatalogo == null) {
                    _getCiudad().then(function (response) {
                        storageCatalogo = localStorageService.get('catalogoCiudad');

                        return storageCatalogo;
                    });
                }

                return storageCatalogo;
            };

            catalogoServiceFactory.catalogoParentesco = _catalogoParentesco;
            catalogoServiceFactory.catalogoSexo = _catalogoSexo;
            catalogoServiceFactory.catalogoNacionalidad = _catalogoNacionalidad;
            catalogoServiceFactory.catalogoProvincia = _catalogoProvincia;
            catalogoServiceFactory.catalogoCiudad = _catalogoCiudad;

            return catalogoServiceFactory;
        }
    ]);