'use strict';
proyectoApp.controller('appController',
    ['$location', '$scope', 'authService',
        function ($location, $scope, authService) {

            $scope.isLoggedIn = authService.authentication.isAuth;

            if ($scope.isLoggedIn) {

                if ($location.path() !== '/home') {

                } else {
                    $location.path('/home');
                }

            } else {
                //$location.path('/login');
            }
        }
    ]);