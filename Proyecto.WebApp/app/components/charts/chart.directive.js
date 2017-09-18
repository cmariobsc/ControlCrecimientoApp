proyectoApp.directive('chart', [
    function () {
        return {
            restrict: 'A',
            template: '<div ng-include="\'app/components/charts/chart.html\'"/>',
            controller: [
                '$scope',
                function ($scope) {

                    $scope.omsBuildChart = function (indicador) {

                        $scope.labels = $scope.meses;
                        $scope.series = [$scope.indicatorTitle, '+3DE', '+2DE', '+1DE',
                            'Mediana', '-1DE', '-2DE', '-3DE'];

                        $scope.childrenData = [];

                        switch (indicador) {
                            case '1':
                                angular.forEach($scope.listChildren, function (value, key) {
                                    $scope.childrenData.push({ x: value.edadTotalMeses, y: value.talla });
                                });
                                break;
                            case '2':
                                angular.forEach($scope.listChildren, function (value, key) {
                                    $scope.childrenData.push({ x: value.edadTotalMeses, y: value.peso });
                                });
                                break;
                            case '3':
                                angular.forEach($scope.listChildren, function (value, key) {
                                    $scope.childrenData.push({ x: value.edadTotalMeses, y: value.imc });
                                });
                                break;
                            case '4':
                                angular.forEach($scope.listChildren, function (value, key) {
                                    $scope.childrenData.push({ x: value.edadTotalMeses, y: value.perimCefalico });
                                });
                                break;
                            case '5':
                                angular.forEach($scope.listChildren, function (value, key) {
                                    $scope.childrenData.push({ x: value.edadTotalMeses, y: value.perimMedioBrazo });
                                });
                                break;
                            default:
                        }

                        $scope.data = [];

                        $scope.data.push(
                            $scope.childrenData,
                            $scope.sD3,
                            $scope.sD2,
                            $scope.sD1,
                            $scope.sD0,
                            $scope.sD1neg,
                            $scope.sD2neg,
                            $scope.sD3neg
                        );

                        $scope.onClick = function (points, evt) {
                            console.log(points, evt);
                        };
                        $scope.datasetOverride = [];
                        $scope.options = {
                            title: {
                                display: true,
                                text: $scope.chartTitle
                            },
                            scales: {
                                yAxes: [
                                    {
                                        id: 'y-axis-1',
                                        type: 'linear',
                                        display: true,
                                        position: 'left'
                                    },
                                    {
                                        id: 'y-axis-2',
                                        type: 'linear',
                                        display: true,
                                        position: 'right'
                                    }
                                ]
                            }
                        };
                    }
                }]
        }
    }
]);