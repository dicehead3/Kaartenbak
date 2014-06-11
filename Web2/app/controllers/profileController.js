app.controller('profileController', [
    "$scope", "$rootScope", 'userService', function($scope, $rootScope, userService) {

        $scope.save = function() {
            userService.save($scope.user).success(function(data) {

            });
        };
    }
]);