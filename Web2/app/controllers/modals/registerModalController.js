app.controller('registerModalController', ['$scope', '$modalInstance', 'loginService', 
    function ($scope, $modalInstance, loginService) {

        $scope.user = {
            username: '',
            name: '',
            email: '',
            password: '',
            passwordVerification: ''
        };
        $scope.form = {
            submitted: false
        };
        $scope.error = {
            showError: false,
            errorText: ''
        };

        $scope.register = function () {

            $scope.form.submitted = true;

            if ($scope.form.register_form.$invalid) {
                return;
            }

            loginService.register($scope.user).success(function (data) {

                if (data.registerSuccessfull == true) {

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