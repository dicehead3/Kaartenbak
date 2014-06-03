app.controller('loginController', ["$scope", "$rootScope", "$location", "loginService",
    function ($scope, $rootScope, $location, loginService) {

        $rootScope.loginPage = true;

    $scope.user = {
        username: '',
        name: '',
        email: '',
        password: '',
        passwordVerification: ''
    };

    $scope.showRegister = false;

    $scope.submitted = false;

    $scope.login = function () {

        $scope.submitted = true;

        if ($scope.login_form.$invalid) {
            return;
        }

        var userLogin = {
            username: $scope.user.username,
            password: $scope.user.password
        };

        loginService.login(userLogin).success(function (data) {
            
            if (data.loginSuccessfull == true) {

                $rootScope.loginPage = false;

                $scope.$apply($location.url("/Overview/Dashboard"));
            } else {
                //add flash message to show an error occured
                console.log('error', data.Message);
            }
        });
    };

    $scope.registerUser = function() {

        $scope.submitted = true;

        if ($scope.login_form.$invalid) {
            return;
        }

        loginService.register($scope.user).success(function(data) {

            if (data.registerSuccessfull == true) {

                $rootScope.loginPage = false;

                $scope.registerSuccessfull = true;

                $scope.$apply($location.url("/Overview/Dashboard"));
            } else {
                console.log('register error', data.Message);
            }
        });
    };

    $scope.goToRegister = function() {

        $scope.showRegister = true;
    };

    $scope.goToSignIn = function() {

        $scope.showRegister = false;
    };

}]);