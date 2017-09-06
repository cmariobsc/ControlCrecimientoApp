'use strict';
proyectoApp.factory('childrenService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var childrenServiceFactory = {}

        var serviceUrl = appConfig.apiUrl;

        var _getListChildren = function (idRepresentante) {
            var url = serviceUrl + '/children/listChildren';
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idRepresentante: idRepresentante }
            }).then(function(response) {
                var result = response.data;
                deferred.resolve(result);
            },function(error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        var _saveChildren = function (children) {

            var url = serviceUrl + '/children/save';
            var deferred = $q.defer();

            $http({
                url: url,
                method: 'POST',
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded; charset=utf-8"
                },
                data: children,
                dataType: 'json'

            }).then(function (response) {
                deferred.resolve(response);
            }, function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        };

        childrenServiceFactory.getListChildren = _getListChildren;
        childrenServiceFactory.saveChildren = _saveChildren;

        return childrenServiceFactory;
    }
    ]);