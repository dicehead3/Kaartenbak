app.controller("overviewController", [
    "$scope", "$rootScope", function($scope, $rootScope) {

        $scope.selectedTab = "dashboard";

        $rootScope.user = {
            name: "strikejester"
        };
        //$rootScope.user.name = "strikejester";


        $scope.goToDashboard = function() {

            $scope.selectedTab = "dashboard";
            $scope.$apply($location.url("/Overview/Dashboard"));
        };

        $scope.goToCollection = function() {

            $scope.selectedTab = "collection";
        };

        $scope.goToDecks = function() {

            $scope.selectedTab = "decks";
        }

    }
]);