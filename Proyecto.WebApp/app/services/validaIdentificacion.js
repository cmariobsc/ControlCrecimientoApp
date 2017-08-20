'use strict';
proyectoApp.factory('validaIdentificacionService',
    [
        '$http',
        function ($http) {
            var validaIdentificacionServiceFactory = {}
            var _validarCedula = function (ced) {
                var i;
                var cedula = ced;
                var acumulado;
                var instancia;
                acumulado = 0;

                if (cedula != undefined && cedula != "") {
                    for (i = 1; i <= 9; i++) {
                        if (i % 2 != 0) {
                            instancia = cedula.substring(i - 1, i) * 2;
                            if (instancia > 9) instancia -= 9;
                        } else instancia = cedula.substring(i - 1, i);
                        acumulado += parseInt(instancia);
                    }
                    while (acumulado > 0)
                        acumulado -= 10;
                    if (cedula.substring(9, 10) != (acumulado * -1)) {
                        return false;
                    } else {
                        return true;
                    }
                }
            }
            validaIdentificacionServiceFactory.validarCedula = _validarCedula;

            return validaIdentificacionServiceFactory;
        }]);