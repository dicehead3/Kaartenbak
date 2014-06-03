app.controller('ChangeEmailModalController', ['$scope', '$modalInstance', 'userId', 'userService', '$translate',
    function ($scope, $modalInstance, userId, userService, $translate) {

        $scope.emailInfo = {
            password: '',
            newEmail: '',
            emailVerification: ''
        };
        $scope.form = {
            submitted: false
        };

        $scope.confirm = function () {
            $scope.form.submitted = true;

            if ($scope.form.change_email_form.$invalid) {
                return;
            }

            $scope.isBlocked = true;

            userService.changeEmail(userId, $scope.emailInfo).success(function (data) {

                $scope.isBlocked = false;

                if (data.result == 'PasswordIncorrect') {
                    $scope.showError = true;
                    $scope.errorText = $translate.translations.settings.oldPasswordIncorrect;
                } else if (data.result == 'NotMatching') {
                    $scope.showError = true;
                    $scope.errorText = $translate.translations.settings.emailNotMatching;
                } else if (data.result == 'Invalid') {
                    $scope.showError = true;
                    $scope.errorText = $translate.translations.settings.noValidEmailAddress;
                } else {
                    $modalInstance.close($scope.emailInfo.newEmail);
                }
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);