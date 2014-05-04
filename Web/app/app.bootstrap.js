var app = angular.module('mainApp', ["ngRoute"]);

app.config([
    '$routeProvider', function($routeProvider) {

        $routeProvider
            .when('/Login', { templateUrl: '/app/views/login.html', controller: 'loginController' })
            .when('/Overview', { templateUrl: '/app/views/main.html', controller: 'overviewController' })
            .when('/Overview/Collection', { templateUrl: '/app/views/overview/collection.html', controller: 'collectionController' })
            .otherwise({ redirectTo: '/Login' });
    }
]);

window.app = app;