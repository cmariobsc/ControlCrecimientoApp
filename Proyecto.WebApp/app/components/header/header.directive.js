proyectoApp.directive('headerProyecto', [
    'authService', 'usuarioService',
    function (authService, usuarioService) {
        return {
            restrict: 'A',
            template: '<div ng-include="\'app/components/header/header.html\'"/>',
            controller: [
                '$scope','$location',
                function ($scope, $location) {
                    $scope.isLoggedIn = authService.authentication.isAuth;
                    $scope.username = authService.authentication.username;
                    $scope.datosSesion = usuarioService.getDatosSesion();
                    
                    $scope.logOut = function () {
                        authService.logOut();
                        window.localStorage.clear();
                        $location.path("/");
                    }
                }]
        }
    }
]);