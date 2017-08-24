proyectoApp.factory('authInterceptorService',
    ['$q', '$location', 'localStorageService', '$window', 'AppConfig', '$injector',
    function ($q, $location, localStorageService, $window, appConfig, $injector) {

        var authInterceptorServiceFactory = {}

        var _request = function (config) {

            config.headers = config.headers || {};
            var token = $window.sessionStorage.token;
            if (token) {
                config.headers.Authorization = 'Bearer ' + token;
            }

            return config;
        }


        var cleanUserData = function () {

            $window.sessionStorage.removeItem("token");
            $window.sessionStorage.removeItem("refreshToken");
            $window.sessionStorage.removeItem("useRefreshTokens");
            $window.sessionStorage.removeItem("username");

            //var authService = $injector.get('authService');
            //authService.logOut();
            $location.path('/login');
            // alert('antes de salir a login');
        };



        var _responseError = function (rejection) {

            if (rejection.status === 401) {

                cleanUserData();
                return $q.reject(rejection);
            }

            return $q.reject(rejection);
        }


        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;
    }


    ]);