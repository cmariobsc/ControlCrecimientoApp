'use strict';
proyectoApp.config(
    ['$routeProvider',
        function ($routeProvider) {

            $routeProvider.when('/app',
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
                .when('/representante',
                {
                    templateUrl: 'app/views/representante.html',
                    controller: 'representanteController'
                })
                .when('/children',
                {
                    templateUrl: 'app/views/children.html',
                    controller: 'childrenController'
                })
                .when('/historialChildren',
                {
                    templateUrl: 'app/views/historialChildren.html',
                    controller: 'historialChildrenController'
                })
        }]);