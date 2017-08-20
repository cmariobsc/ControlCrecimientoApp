'use strict';

var proyectoApp = angular.module('ProyectoApp',
    [
        'ngRoute',
        'ngTable',
        'tableSort',
        'LocalStorageModule',
        'angular-loading-bar',
        'angular-growl',
        'ngEkathuwa',
        'ui.bootstrap',
        'blockUI'
]);

proyectoApp.constant('AppConfig',
{
    apiUrl: "http://localhost:54749",
    useRefreshTokens: false,
    clientAppId: "proyecto_app"
});

proyectoApp.run(
    ['authService', function (authService) {
        authService.fillAuthData();
    }]);

proyectoApp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
}]);

proyectoApp.config(
    ['blockUIConfig', function (blockUIConfig) {
        blockUIConfig.message = 'Procesando... ';
        blockUIConfig.delay = 100;
    }]);
