app.controller('loginController', ["$scope", "$rootScope", "$location", "userService",
    function ($scope, $rootScope, $location, userService) {

    $scope.user = {
        email: '',
        password: ''
    };

    $scope.submitted = false;

    $scope.login = function () {

        $scope.submitted = true;

        if ($scope.login_form.$invalid) {
            return;
        }

        userService.login($scope.user).success(function (data) {
            console.log(data, typeof(data.loginSuccessfull));
            if (data.loginSuccessfull == true) {

                $scope.$apply($location.url("/Overview/Dashboard"));
            } else {
                //add flash message to show an error occured
                console.log('error', data.Message);
            }
        });
    };

    $scope.resetPassword = function() {
        console.log('resetPassword');
    };

    $scope.register = function() {
        console.log('register');
    };
}]);