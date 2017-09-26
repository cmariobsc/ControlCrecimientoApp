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

            $scope.calculaIMC = function () {
                var alturaCuadrado = Math.pow($scope.datoChildren.talla / 100, 2);
                var imc = $scope.datoChildren.peso / alturaCuadrado;
                $scope.datoChildren.imc = roundToTwo(imc);

                /*Calculo descripcion IMC*/
                if (imc < 16) {
                    $scope.datoChildren.detalleIMC = "Delgadez Severa";
                }
                else if (imc < 17) {
                    $scope.datoChildren.detalleIMC = "Delgadez Moderada";
                }
                else if (imc < 18.5) {
                    $scope.datoChildren.detalleIMC = "Delgadez Aceptable";
                }
                else if (imc < 25) {
                    $scope.datoChildren.detalleIMC = "Peso Normal";
                }
                else if (imc < 30) {
                    $scope.datoChildren.detalleIMC = "Sobrepeso";
                }
                else if (imc < 35) {
                    $scope.datoChildren.detalleIMC = "Obeso: Tipo I";
                }
                else if (imc < 40) {
                    $scope.datoChildren.detalleIMC = "Obeso: Tipo II";
                }
                else if (imc >= 40) {
                    $scope.datoChildren.detalleIMC = "Obeso: Tipo III";
                }
            }

            function roundToTwo(num) {
                return +(Math.round(num + "e+2") + "e-2");
            }
        }
    ]);