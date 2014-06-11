var app = angular.module('mainApp', ['ngRoute', 'ui.bootstrap']);

app.config([
    '$routeProvider', function($routeProvider) {

        $routeProvider
            .when('/Index', {templateUrl: '/app/views/main.html'})
            .when('/Overview', { templateUrl: '/app/views/menu.html' })
            .when('/Collection', { templateUrl: '/app/views/overview/collection.html' })
            .when('/Dashboard', { templateUrl: '/app/views/dashboard.html', controller: 'dashboardController' })
            .when('/Profile', { templateUrl: '/app/views.profile.html'})
            .otherwise({ redirectTo: '/Index' });
    }
]);

window.app = app;