'use strict';
proyectoApp.factory('childrenService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var childrenServiceFactory = {}

        var serviceUrl = appConfig.apiUrl;

        var _getListChildren = function (idRepresentante) {
            var url = serviceUrl + '/children/getList';
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

        var _getChildren = function (idChildren) {
            var url = serviceUrl + '/children/get';
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idChildren: idChildren }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
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

        var _editChildren = function (children) {

            var url = serviceUrl + '/children/edit';
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

        var _deleteChildren = function (idChildren) {
            var url = serviceUrl + '/children/delete';
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idChildren: idChildren }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        var _getListHistorialChildren = function (idChildren) {
            var url = serviceUrl + '/children/getListHistorial';
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { idChildren: idChildren }
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        childrenServiceFactory.getListChildren = _getListChildren;
        childrenServiceFactory.getChildren = _getChildren;
        childrenServiceFactory.saveChildren = _saveChildren;
        childrenServiceFactory.editChildren = _editChildren;
        childrenServiceFactory.deleteChildren = _deleteChildren
        childrenServiceFactory.getListHistorialChildren = _getListHistorialChildren;

        return childrenServiceFactory;
    }
    ]);