'use strict';
proyectoApp.factory('childrenService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var childrenServiceFactory = {}

        var serviceUrl = appConfig.apiUrl;

        var _getChildren = function (idRepresentante) {
            var url = serviceUrl + '/children/listChildren';
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url,
                crossDomain: true,
                cache: false,
                params: { IdRepresentante: idRepresentante }
            }).then(function(response) {
                var result = response.data;
                deferred.resolve(result);
            },function(error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        //var _postActivities = function () {

        //    var url = serviceUrl + '/actividad/post';
        //    var deferred = $q.defer();

        //    $http({
        //        method: 'POST',
        //        url: url,
        //        data: { model: $scope.Payout },
        //        crossDomain: true
        //    }).then(function (response) {

        //        var result = response.data;
        //        deferred.resolve(result);


        //    }, function (error) {
        //        deferred.reject(error);
        //    });

        //    return deferred.promise;
        //};

        //// eliminar 
        //var _deleteActivities = function (idAct, user) {
         
        //    var url = serviceUrl + '/actividad/eliminar';
        //    var deferred = $q.defer();

        //    $http({
        //        url: url,
        //        method: 'POST',
        //        headers: {
        //            "Content-Type": "application/x-www-form-urlencoded; charset=utf-8"
        //        },
        //        params: { id: idAct, usuarioModificacion: user },
        //        dataType: 'json'

        //    }).then(function (response) {
                
        //        var result = response.data;
        //        deferred.resolve(result);
                
        //    }, function (error) {
        //        deferred.reject(error);
        //    });
        //    return deferred.promise;
        //};
        //// consultar
        //var _getActivity = function (idActividad) {
        //    var url = serviceUrl + '/actividad/Get';
        //    var deferred = $q.defer();

        //    $http({
        //        method: 'POST',
        //        url: url,
        //        crossDomain: true,
        //        cache: false,
        //        params: { idActividad: idActividad }
        //    }).then(function (response) {

        //        var result = response.data;
        //        deferred.resolve(result);


        //    }, function (error) {
        //        deferred.reject(error);
        //    });

        //    return deferred.promise;
        //};

        //// actualizar

        //var _updateActivities = function () {

        //    var url = serviceUrl + '/actividad/update';
        //    var deferred = $q.defer();

        //    $http({
        //        method: 'POST',
        //        url: url,
        //        data: { model: $scope.Payout },
        //        crossDomain: true
        //    }).then(function (response) {

        //        var result = response.data;
        //        deferred.resolve(result);


        //    }, function (error) {
        //        deferred.reject(error);
        //    });

        //    return deferred.promise;
        //};

        childrenServiceFactory.getChildren = _getChildren;
        //activitiesServiceFactory.postActivities = _postActivities;
        //activitiesServiceFactory.deleteActivities = _deleteActivities; // eliminar
        //activitiesServiceFactory.getActivity = _getActivity; // consultar
        //activitiesServiceFactory.updateActivities = _updateActivities; // actualizar

        return childrenServiceFactory;
    }
    ]);