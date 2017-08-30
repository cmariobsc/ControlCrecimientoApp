'use strict';
proyectoApp.config(
    ['$routeProvider',
        function ($routeProvider) {

            $routeProvider.when('/',
                {
                    templateUrl: 'app/views/app.html',
                    controller: 'appController'
                }).when('/login',
                {
                    templateUrl: 'app/views/login.html',
                    controller: 'loginController'
                }).when('/registro',
                {
                    templateUrl: 'app/views/registro.html',
                    controller: 'registroController'
                })
                .when('/home',
                {
                    templateUrl: 'app/views/home.html',
                    controller: 'homeController'
                })
                .when('/datoRepresentante',
                {
                    templateUrl: 'app/views/representante.html',
                    controller: 'representanteController'
                })

                .when('/datoChildren',
                {
                    templateUrl: 'app/views/children.html',
                    controller: 'childrenController'
                })

        }]);