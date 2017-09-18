'use strict';
proyectoApp.controller('historialChildrenController',
    ['$ekathuwa', 'childrenService', '$filter', '$compile', '$timeout', 'NgTableParams', '$scope', '$rootScope', 'AppConfig', 'catalogoService', 'omsInfoService', 'emailService',
        function ($ekathuwa, childrenService, $filter, $compile, $timeout, NgTableParams, $scope, $rootScope, appConfig, catalogoService, omsInfoService, emailService) {

            $scope.listNacionalidad = catalogoService.catalogoNacionalidad();
            $scope.listProvincia = catalogoService.catalogoProvincia();
            $scope.listCiudad = catalogoService.catalogoCiudad();
            $scope.listSexo = catalogoService.catalogoSexo();
            $scope.listDoctores = catalogoService.catalogoDoctor();

            $scope.listChildren = [];

            $scope.listIndicadores = [
                {
                    idIndicador: '1',
                    descripcion: 'Talla para la edad'
                },
                {
                    idIndicador: '2',
                    descripcion: 'Peso para la edad'
                },
                {
                    idIndicador: '3',
                    descripcion: 'Masa Corporal para la edad'
                },
                {
                    idIndicador: '4',
                    descripcion: 'Perímetro Cefálico para la edad'
                },
                {
                    idIndicador: '5',
                    descripcion: 'Perímetro Medio del Brazo para la edad'
                }
            ];

            $scope.doctor = 0;
            $scope.indicador = 0;

            $scope.getListChildren = function () {
                childrenService.getListChildren($rootScope.idRepresentante)
                    .then(function (response) {
                        $scope.children_message = response.mensajeRetorno;
                        var data = response.data;

                        $scope.childrenTable = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: data
                            });

                    }, function (error) { });
            }

            $scope.getListChildren();

            $scope.consultar = function (idChildren) {
                childrenService.getListHistorialChildren(idChildren)
                    .then(function (response) {
                        $scope.history_message = response.mensajeRetorno;
                        var data = response.data;
                        $scope.nombreCompleto = data[0].nombreCompleto;
                        $scope.idSexo = data[0].idSexo;

                        $scope.listChildren = data;

                        $scope.historyTable = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: data
                            });

                    }, function (error) { });
            }

            $scope.obtenerNacionalidad = function (idNacionalidad) {
                var descripcion = "";
                angular.forEach($scope.listNacionalidad, function (value, key) {
                    if (value.idNacionalidad == idNacionalidad) {
                        descripcion = value.descripcion;
                    }
                });

                return descripcion;
            }

            $scope.obtenerProvincia = function (idProvincia) {
                var descripcion = "";
                angular.forEach($scope.listProvincia, function (value, key) {
                    if (value.idProvincia == idProvincia) {
                        descripcion = value.descripcion;
                    }
                });

                return descripcion;
            }

            $scope.obtenerCiudad = function (idCiudad) {
                var descripcion = "";
                angular.forEach($scope.listCiudad, function (value, key) {
                    if (value.idCiudad == idCiudad) {
                        descripcion = value.descripcion;
                    }
                });

                return descripcion;
            }

            $scope.obtenerSexo = function (idSexo) {
                var descripcion = "";
                angular.forEach($scope.listSexo, function (value, key) {
                    if (value.idSexo == idSexo) {
                        descripcion = value.descripcion;
                    }
                });

                return descripcion;
            }

            $scope.cargarGrafica = function (indicador) {

                switch (indicador) {
                    case '1':
                        omsInfoService.getListTallaxEdad($scope.idSexo)
                            .then(function (response) {
                                var data = response.data;
                                $scope.indicatorTitle = 'Talla del Niño'
                                $scope.chartTitle = response.mensajeRetorno;
                                obtenerParametro(data);
                                $scope.omsBuildChart(indicador);
                            });
                        break;
                    case '2':
                        omsInfoService.getListPesoxEdad($scope.idSexo)
                            .then(function (response) {
                                var data = response.data;
                                $scope.indicatorTitle = 'Peso del Niño'
                                $scope.chartTitle = response.mensajeRetorno;
                                obtenerParametro(data);
                                $scope.omsBuildChart(indicador);
                            });
                        break;
                    case '3':
                        omsInfoService.getListIMCxEdad($scope.idSexo)
                            .then(function (response) {
                                var data = response.data;
                                $scope.indicatorTitle = 'Masa Corporal del Niño'
                                $scope.chartTitle = response.mensajeRetorno;
                                obtenerParametro(data);
                                $scope.omsBuildChart(indicador);
                            });
                        break;
                    case '4':
                        omsInfoService.getListPCxEdad($scope.idSexo)
                            .then(function (response) {
                                var data = response.data;
                                $scope.indicatorTitle = 'Perímetro Cefálico del Niño'
                                $scope.chartTitle = response.mensajeRetorno;
                                obtenerParametro(data);
                                $scope.omsBuildChart(indicador);
                            });
                        break;
                    case '5':
                        omsInfoService.getListPMBxEdad($scope.idSexo)
                            .then(function (response) {
                                var data = response.data;
                                $scope.indicatorTitle = 'Perímetro Medio del Brazo del Niño'
                                $scope.chartTitle = response.mensajeRetorno;
                                obtenerParametro(data);
                                $scope.omsBuildChart(indicador);
                            });
                        break;
                    default:
                }
            }

            $scope.consultarDoctor = function (idDoctor) {
                angular.forEach($scope.listDoctores, function (value, key) {
                    if (value.idDoctor == idDoctor) {
                        $scope.doctorSelect = [];
                        $scope.doctorSelect.push(value);
                        $scope.emailDoctor = value.email;
                        $scope.nombreDoctor = value.nombre;
                        $scope.doctorTable = new NgTableParams({
                            page: 1,
                            count: 10
                        },
                            {
                                dataset: $scope.doctorSelect
                            });
                    }
                });
            }

            var obtenerParametro = function (data) {
                $scope.meses = [];
                $scope.sD3neg = [];
                $scope.sD2neg = [];
                $scope.sD1neg = [];
                $scope.sD0 = [];
                $scope.sD1 = [];
                $scope.sD2 = [];
                $scope.sD3 = [];
                angular.forEach(data, function (value, key) {
                    if (key < ($scope.listChildren[$scope.listChildren.length - 1].edadTotalMeses + 6)) {
                        $scope.meses.push(value.meses);
                        $scope.sD3neg.push(value.sD3neg);
                        $scope.sD2neg.push(value.sD2neg);
                        $scope.sD1neg.push(value.sD1neg);
                        $scope.sD0.push(value.sD0);
                        $scope.sD1.push(value.sD1);
                        $scope.sD2.push(value.sD2);
                        $scope.sD3.push(value.sD3);
                    }
                });
            }

            $scope.sendEmail = function () {

                var canvasImage = document.getElementById("line");
                var image = new Image();
                image.src = canvasImage.toDataURL("image/png");

                var html = '<p>Buenos días Dr(a), reciba un cordial saludo.</p> <br />' +
                    '<p>Soy ' + $rootScope.nombreCompleto + ',</p>' +
                    '<p>Le hago llegar el histrorial de crecimiento de mi representado, ' + $scope.nombreCompleto +
                    ', el cual detallo a continuación: </p>' +
                    '<p></p><br />' +
                    '<table ng-table="historyTable">' +
                        '<thead>' +
                            '<tr>' +
                                '<th>#</th>' +
                                '<th>Fecha</th>' +
                                '<th>Edad</th>' +
                                '<th>Talla (cm)</th>' +
                                '<th>Peso (kg)</th>' +
                                '<th>IMC (cm)</th>' +
                                '<th>Detalle IMC</th>' +
                                '<th>PC (cm)</th>' +
                                '<th>PMB (cm)</th>' +
                                '<th>Observaciones</th>' +
                            '</tr>' +
                        '</thead>' +
                        '<tbody>' +
                            '<tr ng-repeat="item in $data | orderBy:sortType:sortReverse">' +
                                '<td>{{ $index + 1 }}</td>' +
                                '<td>{{ item.fechaCreacion | date : "dd/MM/yyyy"}}</td>' +
                                '<td>{{ item.edadAnios }} Años {{ item.edadMeses }} Meses (Total Meses: {{ item.edadTotalMeses }})</td>' +
                                '<td>{{ item.talla }}</td>' +
                                '<td>{{ item.peso }}</td>' +
                                '<td>{{ item.imc }}</td>' +
                                '<td>{{ item.detalleIMC }}</td>' +
                                '<td>{{ item.perimCefalico }}</td>' +
                                '<td>{{ item.perimMedioBrazo }}</td>' +
                                '<td>{{ item.observaciones }}</td>' +
                            '</tr>' +
                        '</tbody>' +
                    '</table>' +
                    '<hr /><p></p><br />' +
                    '<img src="' + image.src + '" width="850" />' +
                    '<hr /><p></p><br />' +
                    'Puede contactare conmigo de las siguientes maneras:' +
                    '<p></p>' +
                    '<br />' +
                    '<p><strong>Email:</strong> ' + $rootScope.email + '</p>' +
                    '<p><strong>Convencional:</strong> ' + $rootScope.convencional + '</p>' +
                    '<p><strong>Celular:</strong> ' + $rootScope.celular + '</p>' +
                    '<p></p>' +
                    '<br />' +
                    '<p>Quedo atento a sus comentarios, muchas gracias por su atención.</p>';
                    

                var factory = angular.element('<div></div>');
                factory.html(html);
                $compile(factory)($scope);

                $timeout(function () {
                    var cuerpo = factory.html();
                    var email = $.param({
                        EmailDestinatario: $scope.emailDoctor,
                        NombreDestinatario: $scope.nombreDoctor,
                        Asunto: 'Historial de Crecimiento del Niño(a): ' + $scope.nombreCompleto,
                        Cuerpo: cuerpo,
                    });

                    emailService.sendEmail(email)
                        .then(function (response) {
                            $scope.ModalMensaje(response.mensajeRetorno);
                        }, function (error) { });
                });
            }

            $scope.ModalMensaje = function (mensaje) {
                $scope.header = "Historial de Crecimientos";
                $scope.body = "" + mensaje;
                $ekathuwa.modal({
                    id: "ModalAlertaId",
                    scope: $scope,
                    backdrop: "static",
                    templateURL: "app/components/modals/alerta.html"
                });
            }

        }]);