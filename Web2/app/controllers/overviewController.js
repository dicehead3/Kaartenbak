app.controller("overviewController", [
    "$scope", "$rootScope", "$modal", function($scope, $rootScope, $modal) {

        $scope.selectedTab = "dashboard";

        //User should be injected
        $rootScope.user = null;/*{
            name: "strikejester"
        };*/

        $scope.goToDashboard = function() {

            $scope.selectedTab = "dashboard";
            $scope.$apply($location.url("/Overview/Dashboard"));
        };

        $scope.goToCollection = function() {

            $scope.selectedTab = "collection";
        };

        $scope.goToDecks = function() {

            $scope.selectedTab = "decks";
        };

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
    }
]);