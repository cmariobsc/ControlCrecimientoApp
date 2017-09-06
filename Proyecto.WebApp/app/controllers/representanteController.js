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
                angular.forEach($scope.listProvincia, function (value, key) {
                    if (value.idProvincia == idProvincia) {
                        $scope.datoRepresentante.codArea = value.codigoArea;
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

            $scope.datoRepresentante.fechaNacimiento = dateAgo;
            //////////////////////////////////////

            $scope.consultar = function () {
                representanteService.getRepresentante($rootScope.datosSesion.idUsuario).then(function (response) {
                    if (response.data.codError === "000") {
                        var representante = response.data;
                        $scope.idRepresentante = representante.data.idRepresentante;
                        $scope.datoRepresentante.parentesco = representante.data.idParentesco;
                        $scope.datoRepresentante.identificacion = representante.data.identificacion;
                        $scope.datoRepresentante.nombres = representante.data.nombres;
                        $scope.datoRepresentante.apellidos = representante.data.apellidos;
                        $scope.datoRepresentante.fechaNacimiento = new Date(representante.data.fechaNacimiento);
                        $scope.datoRepresentante.edad = representante.data.edad;
                        $scope.datoRepresentante.nacionalidad = representante.data.idNacionalidad;
                        $scope.datoRepresentante.provincia = representante.data.idProvincia;
                        $scope.cargaCiudad(representante.data.idProvincia);
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

            $scope.actualizar = function () {
                var representante = $.param({
                    IdRepresentante: $scope.idRepresentante,
                    Identificacion: $scope.datoRepresentante.identificacion,
                    Nombres: $scope.datoRepresentante.nombres,
                    Apellidos: $scope.datoRepresentante.apellidos,
                    FechaNacimiento: $filter('date')($scope.datoRepresentante.fechaNacimiento, 'yyyy/MM/dd'),
                    Edad: $scope.datoRepresentante.edad,
                    Direccion: $scope.datoRepresentante.direccion,
                    Email: $scope.datoRepresentante.email,
                    Telefono1: $scope.datoRepresentante.numTelefono,
                    Telefono2: $scope.datoRepresentante.numTelefono2,
                    Talla: $scope.datoRepresentante.talla,
                    Peso: $scope.datoRepresentante.peso,
                    NHijos: $scope.datoRepresentante.hijos,
                    IdParentesco: $scope.datoRepresentante.parentesco,
                    IdNacionalidad: $scope.datoRepresentante.nacionalidad,
                    IdProvincia: $scope.datoRepresentante.provincia,
                    IdCiudad: $scope.datoRepresentante.ciudad
                });

                representanteService.editRepresentante(representante).then(function (response) {
                    if (response.data.codError === "000") {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    } else {
                        $scope.ModalMensaje(response.data.mensajeRetorno);
                    }
                });
            }

            $scope.calculateAge = function calculateAge(birthday) {
                var ageDifMs = Date.now() - birthday.getTime();
                var ageDate = new Date(ageDifMs);
                $scope.datoRepresentante.edad = Math.abs(ageDate.getUTCFullYear() - 1970);
            }

            $scope.regresar = function () {
                $(document).unbind('keydown');

                if ($scope.datosRepresentanteForm.$dirty) {
                    $scope.modalRegresar("¿Desea regresar sin guardar los cambios?");
                } else {
                    $scope.go_back();
                }
            }

            $scope.go_back = function () {
                $location.url("home");
                window.scrollTo(0, 0);
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

            $scope.modalRegresar = function (mensaje) {

                $scope.header = "Datos del Representante";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalConfirmacionId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/confirmacion.html"
                });
            }

            $scope.consultar();
        }]);