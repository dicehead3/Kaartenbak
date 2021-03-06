﻿app.controller('loginModalController', ['$scope', '$modalInstance', 'loginService',
    function ($scope, $modalInstance, loginService) {

        $scope.user = {
            username: '',
            password: ''
        };
        $scope.form = {
            submitted: false
        };
        $scope.error = {
            showError: false,
            errorText: ''
        };

        $scope.login = function() {

            $scope.form.submitted = true;

            if ($scope.form.login_form.$invalid) {
                return;
            }

            loginService.login($scope.user).success(function(data) {

                if (data.loginSuccessfull == true) {

                    $modalInstance.close(data.user);
                } else {

                    $scope.error.showError = true;
                    $scope.error.errorText = data.Message;
                }
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);