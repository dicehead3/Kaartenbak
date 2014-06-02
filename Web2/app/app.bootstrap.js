var app = angular.module('mainApp', ["ngRoute"]);

app.config([
    '$routeProvider', function($routeProvider) {

        $routeProvider
            .when('/Login', { templateUrl: '/app/views/login.html' })
            .when('/Overview', { templateUrl: '/app/views/main.html' })
            .when('/Overview/Collection', { templateUrl: '/app/views/overview/collection.html' })
            .when('/Overview/Dashboard', { templateUrl: '/app/views/dashboard.html', controller: 'dashboardController'})
            .otherwise({ redirectTo: '/Login' });
    }
]);

window.app = app;