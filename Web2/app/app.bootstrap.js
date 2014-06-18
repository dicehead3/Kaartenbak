var app = angular.module('mainApp', ['ngRoute', 'ui.bootstrap']);

app.config([
    '$routeProvider', function($routeProvider) {

        $routeProvider
            .when('/Index', {templateUrl: '/app/views/main.html'})
            .when('/Collection', { templateUrl: '/app/views/overview/collection.html' })
            //.when('/Dashboard', { templateUrl: '/app/views/dashboard.html', controller: 'dashboardController' })
            //.when('/Profile', { templateUrl: '/app/views.profile.html'})
            .otherwise({ redirectTo: '/Index' });
    }
]);

app.run([
    '$rootScope', '$location', function($rootScope, $location) {

        // register listener to watch route changes
        $rootScope.$on("$routeChangeStart", function(event, next, current) {
            if ($rootScope.loggedUser == null) {
                // no logged user, we should be going to #index
                if (next.templateUrl == "main.html") {
                    // already going to #index, no redirect needed
                } else {
                    // not going to #index, we should redirect now
                    $location.path("/Index");
                }
            }
        });
    }
]);

window.app = app;