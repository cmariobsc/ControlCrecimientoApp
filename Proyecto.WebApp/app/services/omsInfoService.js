'use strict';
proyectoApp.factory('omsInfoService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var omsInfoServiceFactory = {}

        var serviceUrl = appConfig.apiUrl;

        var _getListTallaxEdadMasculino = function () {
            var url = serviceUrl + '/omsInfo/getListTallaxEdadMasculino';
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: url,
                crossDomain: true
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        omsInfoServiceFactory.getListTallaxEdadMasculino = _getListTallaxEdadMasculino;

        return omsInfoServiceFactory;
    }
    ]);