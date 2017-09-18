'use strict';
proyectoApp.factory('omsInfoService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var omsInfoServiceFactory = {}

        var serviceUrl = appConfig.apiUrl;

        var _getListTallaxEdad = function (idSexo) {
            var url = serviceUrl + '/omsInfo/getListTallaxEdad';
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idSexo: idSexo }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        var _getListPesoxEdad = function (idSexo) {
            var url = serviceUrl + '/omsInfo/getListPesoxEdad';
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idSexo: idSexo }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        var _getListIMCxEdad = function (idSexo) {
            var url = serviceUrl + '/omsInfo/getListIMCxEdad';
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idSexo: idSexo }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        var _getListPCxEdad = function (idSexo) {
            var url = serviceUrl + '/omsInfo/getListPCxEdad';
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idSexo: idSexo }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        var _getListPMBxEdad = function (idSexo) {
            var url = serviceUrl + '/omsInfo/getListPMBxEdad';
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idSexo: idSexo }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        omsInfoServiceFactory.getListTallaxEdad = _getListTallaxEdad;
        omsInfoServiceFactory.getListPesoxEdad = _getListPesoxEdad;
        omsInfoServiceFactory.getListIMCxEdad = _getListIMCxEdad;
        omsInfoServiceFactory.getListPCxEdad = _getListPCxEdad;
        omsInfoServiceFactory.getListPMBxEdad = _getListPMBxEdad;

        return omsInfoServiceFactory;
    }
    ]);