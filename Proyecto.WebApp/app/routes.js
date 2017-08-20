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
                })
                .when('/home',
                {
                    templateUrl: 'app/views/home.html',
                    controller: 'homeController'
                })
                .when('/datoRepresentante',
                {
                    templateUrl: 'app/views/datosRepresentante.html',
                    controller: 'datoRepresentanteController'
                })

                .when('/datoChildren',
                {
                    templateUrl: 'app/views/datosChildren.html',
                    controller: 'datoChildrenController'
                })

        }]);