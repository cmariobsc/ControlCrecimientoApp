﻿'use strict';
proyectoApp.controller('loginController',
    ['$location', '$scope', 'authService', 'usuarioService', '$ekathuwa',
   function ($location, $scope, authService, usuarioService, $ekathuwa) {

       $scope.loginData = {
           username: "",
           password: ""
       };

       $scope.message = "";

       $scope.login = function () {
           authService.login($scope.loginData)
               .then(function (response) {
                   $scope.armarDatosPrincipales($scope.loginData);
                   },
               function (error) {
                   var errorResult = error.data;
                   $scope.message = errorResult.error_description;
               });
       };

       $scope.armarDatosPrincipales = function (loginData) {
           usuarioService.getUserData(loginData.username, loginData.password)
               .then(function (response) {
                   var datoUsuario = usuarioService.getDatosSesion();
                   $location.path('/home');
               }, function (error) {
                   alert(error);
               });
       };

   }]);