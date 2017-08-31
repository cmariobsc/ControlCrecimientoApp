'use strict';
proyectoApp.controller('representanteController',
    ['$location', '$http', '$q', '$ekathuwa', 'validaIdentificacionService', '$filter', 'localStorageService', '$scope', '$rootScope', '$route', 'AppConfig', 'catalogoService', 'representanteService',
        function ($location, $http, $q, $ekathuwa, validaIdentificacionService, $filter, localStorageService, $scope, $rootScope, $route, appConfig, catalogoService, representanteService) {

            $scope.message = "";

            $scope.listParentesco = catalogoService.catalogoParentesco();

            $scope.listNacionalidad = catalogoService.catalogoNacionalidad();

            $scope.listProvincia = catalogoService.catalogoProvincia();

            var ciudades = catalogoService.catalogoCiudad();
            $scope.cargaCiudad = function (idProvincia) {
                $scope.listCiudad = [];
                angular.forEach(ciudades, function (value, key) {
                    if (value.idProvincia == idProvincia) {
                        $scope.listCiudad.push(value);
                    }
                });
            }

            $scope.validaIdentificacion = validaIdentificacionService;

            //Configuraciones para el popup fecha
            var dateNow = new Date();
            var year = dateNow.getFullYear();
            var month = dateNow.getMonth();
            var day = dateNow.getDate();
            var dateAgo = new Date(year - 15, month, day);

            //Configuraciones para el popup fecha
            $scope.dateOptions = {
                maxDate: dateAgo
            };

            $scope.popup = {
                opened: false
            };

            $scope.abrirCalendario = function () {
                $scope.popup.opened = true;
            };

            $scope.datoRepresentante = {};

            $scope.datoRepresentante.fechaNacimiento = new Date();
            //////////////////////////////////////

            $scope.consultar = function () {
                representanteService.getRepresentante(1).then(function (response) {
                    if (response.data.codError === "000") {
                        var representante = response.data;
                        $scope.datoRepresentante.parentesco = representante.data.idParentesco;
                        $scope.datoRepresentante.identificacion = representante.data.identificacion;
                        $scope.datoRepresentante.nombres = representante.data.nombres;
                        $scope.datoRepresentante.apellidos = representante.data.apellidos;
                        $scope.datoRepresentante.fechaNacimiento = representante.data.fechaNacimiento;
                        $scope.datoRepresentante.edad = representante.data.edad;
                        $scope.datoRepresentante.nacionalidad = representante.data.idNacionalidad;
                        $scope.datoRepresentante.provincia = representante.data.idProvincia;
                        $scope.datoRepresentante.ciudad = representante.data.idCiudad;
                        $scope.datoRepresentante.direccion = representante.data.direccion;
                        $scope.datoRepresentante.email = representante.data.email;
                        $scope.datoRepresentante.numTelefono = representante.data.telefono1;
                        $scope.datoRepresentante.numTelefono2 = representante.data.telefono2;
                        $scope.datoRepresentante.talla = representante.data.talla;
                        $scope.datoRepresentante.peso = representante.data.peso;
                        $scope.datoRepresentante.hijos = representante.data.nHijos;
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.ModalMensaje = function (mensaje) {
                $scope.header = "Datos del Representante";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalAlertaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/alerta.html"
                });
            }

            $scope.consultar();
        }]);