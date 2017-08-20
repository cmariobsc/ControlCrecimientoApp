proyectoApp.directive('headerAnonProyecto',[
    function () {
        return {
            restrict: 'A',
            template: '<div ng-include="\'app/components/header/header-anon.html\'"/>',
            controller: [
                '$scope',
                function ($scope) {

                }]
        }
    }
]);