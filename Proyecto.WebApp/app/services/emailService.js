'use strict';
proyectoApp.factory('emailService',
    ['$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var emailServiceFactory = {}

        var serviceUrl = appConfig.apiUrl;

        var _sendEmail = function (email) {
            var url = serviceUrl + '/email/send';
            var deferred = $q.defer();

            $http({
                url: url,
                method: 'POST',
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded; charset=utf-8"
                },
                data: email,
                dataType: 'json'
            }).then(function (response) {
                var result = response.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        };

        emailServiceFactory.sendEmail = _sendEmail;

        return emailServiceFactory;
    }
    ]);