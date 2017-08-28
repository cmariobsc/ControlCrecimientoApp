'use strict';
proyectoApp.factory('authService',
    ['$http', '$q', '$location', 'localStorageService', '$window', 'AppConfig',
    function ($http, $q, $location, localStorageService, $window, appConfig) {

        var authServiceFactory = {}

        var _authentication = {
            isAuth: false,
            username: "",
            useRefreshTokens: appConfig.useRefreshTokens
        }

        var serviceUrl = appConfig.apiUrl;

        var _login = function (loginData) {

            var data = "grant_type=password" +
                "&username=" + loginData.username +
                "&password=" + loginData.password;
            if (appConfig.useRefreshTokens) {
                data += "&client_id=" + appConfig.clientAppId;
            }

            var deferred = $q.defer();
            $http.post(
                serviceUrl + '/token',
                data,
                {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).then(function (response) {
                    var result = response.data;
                    $window.sessionStorage.token = result.access_token;
                    $window.sessionStorage.username = loginData.username;
                    $window.sessionStorage.useRefreshTokens = appConfig.useRefreshTokens;

                    $window.sessionStorage.refreshToken = '';
                    if (appConfig.useRefreshTokens) {
                        $window.sessionStorage.refreshToken = result.refresh_token;
                    }

                    _authentication.isAuth = true;
                    _authentication.username = loginData.username;
                    _authentication.useRefreshTokens = appConfig.useRefreshTokens;

                    deferred.resolve(response);

                }, function (error) {
                    _logOut();

                    deferred.reject(error);
                });

            return deferred.promise;
        }

        var _Registro = function (usuario) {

            _authentication.isAuth = true;

            var url = serviceUrl + '/auth/registro';
            var deferred = $q.defer();

            $http({
                url: url,
                method: 'POST',
                headers: {
                    Authorization: null
                },
                data: usuario,
                dataType: 'json'

            }).then(function (response) {
                var res = response;
                deferred.resolve(res);
            }, function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        };

        var _logOut = function () {

            $window.sessionStorage.removeItem("token");
            $window.sessionStorage.removeItem("username");
            $window.sessionStorage.removeItem("useRefreshTokens");
            $window.sessionStorage.removeItem("refreshToken");

            _authentication.isAuth = false;
            _authentication.userName = "";
        };

        var _fillAuthData = function () {

            var token = $window.sessionStorage.token;
            var username = $window.sessionStorage.username;

            if (token && username) {
                _authentication.isAuth = true;
                _authentication.username = username;
                _authentication.useRefreshTokens = appConfig.useRefreshTokens;
            } else {
                _authentication.isAuth = false;
                _authentication.username = "";
            }
        }


        var _refreshToken = function () {

            var deferred = $q.defer();

            var token = $window.sessionStorage.token;
            var username = $window.sessionStorage.username;
            var refreshToken = $window.sessionStorage.refreshToken;

            if (token && refreshToken) {

                var data = "grant_type=refresh_token&refresh_token=" + refreshToken + "&client_id=" + AppConfig.clientAppId;
                $http.post(
                    serviceUrl + '/token',
                    data,
                    {
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    }).success(function (response) {

                        $window.sessionStorage.token = response.access_token;
                        $window.sessionStorage.username = username;
                        $window.sessionStorage.useRefreshTokens = appConfig.useRefreshTokens;
                        $window.sessionStorage.refreshToken = response.refresh_token;

                        _authentication.isAuth = true;
                        _authentication.username = username;
                        _authentication.useRefreshTokens = appConfig.useRefreshTokens;
                        _fillAuthData();

                        deferred.resolve(response);

                    }).error(function (err, status) {
                        _logOut();
                        deferred.reject(err);
                    });
            }
            return deferred.promise;
        };


        var _checkLogin = function () {
            var isLoggedIn = _authentication.isAuth;
            if (!isLoggedIn) {
                //$location.path('/login');
            }
        };

        authServiceFactory.checkLogin = _checkLogin;
        authServiceFactory.Registro = _Registro;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;

        return authServiceFactory;
    }
    ]);