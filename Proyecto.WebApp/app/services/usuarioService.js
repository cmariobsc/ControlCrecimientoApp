'use strict';
proyectoApp.factory('usuarioService',
[
    '$http', '$q', 'localStorageService', 'AppConfig',
    function ($http, $q, localStorageService, appConfig) {

        var usuarioServiceFactory = {}

        var _estadoUsuario = {
            datosSesion: null
        };

        var serviceUrl = appConfig.apiUrl;
        var _getUserData = function (username, password) {

            var data = "?username=" + username +
            "&password=" + password;

            var deferred = $q.defer();
            $http({

                method: 'GET',
                url: serviceUrl + "/auth/getuserdata" + data,
                crossDomain: true

            }).then(function(response) {

                var result = response.data;
                if (result.codError === "000") {

                    var dataSesion = {
                        usuario: result.data.usuario,
                        nombres: result.data.nombres,
                        apellidos: result.data.apellidos,
                    };
                    _estadoUsuario.datosSesion = dataSesion;
                    localStorageService.set("datosSesion", dataSesion);
                } else {
                    alert(result.mensajeRetorno);
                }

                deferred.resolve(response);

            }), function(error) {
                deferred.reject(error);
            }

           return deferred.promise;
        };

        var _getDatosSesion = function () {

            var datos = localStorageService.get('datosSesion');
            _estadoUsuario.datosSesion = datos;
            return datos;
        };

        usuarioServiceFactory.getDatosSesion = _getDatosSesion;
        usuarioServiceFactory.getUserData = _getUserData;
        usuarioServiceFactory.estadoUsuario = _estadoUsuario;
        
        return usuarioServiceFactory;

    }]);