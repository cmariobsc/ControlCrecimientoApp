'use strict';
proyectoApp.controller('appController',
    ['$location', '$scope', 'authService',
        function ($location, $scope, authService) {

            $scope.isLoggedIn = authService.authentication.isAuth;

            if ($scope.isLoggedIn) {

                $location.path('/home');

            } else {
                $location.path('/app');
                $scope.appActive = true;
            }
        }
    ]);