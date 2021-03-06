﻿'use strict';
proyectoApp.controller('registroController',
    ['$location', '$scope', '$rootScope', '$ekathuwa', 'localStorageService', 'authService',
        function ($location, $scope, $rootScope, $ekathuwa, localStorageService, authService) {

            $scope.message = "";

            $scope.registrar = function () {
                var usuario = $.param({
                    Usuario: $scope.datoRegistro.usuario,
                    Contrasenia: $scope.datoRegistro.contrasenia,
                    Nombres: $scope.datoRegistro.nombres,
                    Apellidos: $scope.datoRegistro.apellidos,
                    Email: $scope.datoRegistro.email,
                });

                authService.registro(usuario).then(function (response) {
                    if (response.data.codError === "000") {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.ModalMensaje = function (mensaje) {
                $scope.header = "Registro de Usuario";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalAlertaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/alerta.html"
                });
            }

            $scope.go_back = function () {
                window.history.back();
                window.scrollTo(0, 0);
            }

            $scope.cerrar = function () {
                $location.path('/login');
            }
        }
    ]);