app.controller("menuController", [
    "$scope", "$rootScope", "$modal", "$location", function($scope, $rootScope, $modal, $location) {

        $rootScope.selectedTab = "dashboard";

        //User should be injected
        $rootScope.user = null;/*{
            name: "strikejester"
        };*/

        $scope.logout = function() {

            $rootScope.user = null;
            $scope.$apply($location.url("/Login"));
        };

        $scope.login = function () {

            var modalInstance = $modal.open({
                templateUrl: '/app/views/modals/login-modal.html',
                controller: 'loginModalController',
                keyboard: false
            });

            modalInstance.result.then(function(user) {

                $rootScope.user = user;
                //go to dashboard
            });
        };

        $scope.register = function() {

            var modalInstance = $modal.open({
                templateUrl: '/app/views/modals/register-modal.html',
                controller: 'registerModalController',
                keyboard: false
            });

            modalInstance.result.then(function(user) {

                $rootScope.user = user;
            });
        };
    }
]);