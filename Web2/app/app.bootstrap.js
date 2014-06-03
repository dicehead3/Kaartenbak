var app = angular.module('mainApp', ['ngRoute', 'ui.bootstrap']);

app.config([
    '$routeProvider', function($routeProvider) {

        $routeProvider
            .when('/Overview', { templateUrl: '/app/views/main.html' })
            .when('/Overview/Collection', { templateUrl: '/app/views/overview/collection.html' })
            .when('/Overview/Dashboard', { templateUrl: '/app/views/dashboard.html', controller: 'dashboardController'})
            .otherwise({ redirectTo: '/Overview/Dashboard' });
    }
]);

window.app = app;