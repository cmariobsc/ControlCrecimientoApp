'use strict';
proyectoApp.controller('homeController',
    ['$location', '$scope', '$rootScope', '$ekathuwa', 'localStorageService', 'authService',
        function ($location, $scope, $rootScope, $ekathuwa, localStorageService, authService) {
            authService.checkLogin();

     }
    ]);