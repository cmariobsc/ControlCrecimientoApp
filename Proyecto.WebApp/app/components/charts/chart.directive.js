proyectoApp.directive('chartTxe', [
    function () {
        return {
            restrict: 'A',
            template: '<div ng-include="\'app/components/charts/chart-txe.html\'"/>',
            controller: [
                '$scope',
                function ($scope) {

                    $scope.omsTxE = function () {

                        $scope.labels = $scope.meses;
                        $scope.series = ['Talla Niño', '+3DE', '+2DE', '+1DE',
                            'Mediana', '-1DE', '-2DE', '-3DE'];

                        $scope.talla = [];

                        angular.forEach($scope.listChildren, function (value, key) {
                            $scope.talla.push({ x: value.edadMeses, y: value.talla });
                        });

                        $scope.data = [];

                        $scope.data.push(
                            $scope.talla,
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
                        //$scope.datasetOverride = [{ yAxisID: 'y-axis-1' }, { yAxisID: 'y-axis-2' }];
                        $scope.options = {
                            title: {
                                display: true,
                                text: 'Talla Para la Edad en Varones'
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