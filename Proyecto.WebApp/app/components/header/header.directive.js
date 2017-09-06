proyectoApp.directive('headerProyecto', [
    'authService', 'usuarioService','representanteService',
    function (authService, usuarioService, representanteService) {
        return {
            restrict: 'A',
            template: '<div ng-include="\'app/components/header/header.html\'"/>',
            controller: [
                '$scope','$rootScope','$location',
                function ($scope, $rootScope, $location) {
                    $scope.isLoggedIn = authService.authentication.isAuth;
                    $scope.username = authService.authentication.username;
                    $rootScope.datosSesion = usuarioService.getDatosSesion();

                    representanteService.getRepresentante($rootScope.datosSesion.idUsuario).then(function (response) {
                        if (response.data.codError === "000") {
                            var representante = response.data;
                            $rootScope.idRepresentante = representante.data.idRepresentante;
                        } else {
                            console.log(response.data.mensajeRetorno);
                        }
                    });
                    
                    $scope.logOut = function () {
                        authService.logOut();
                        window.localStorage.clear();
                        $location.path("/");
                    }
                }]
        }
    }
]);