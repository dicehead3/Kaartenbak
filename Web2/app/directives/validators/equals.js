app.directive('equals', function () {
    return {
        restrict: 'A',
        require: 'ngModel', // get a hold of NgModelController
        link: function ($scope, elem, attrs, ngModel) {

            if (!ngModel) return; // do nothing if no ng-model
            // watch own value and re-validate on change
            $scope.$watch(attrs.ngModel, function () {
                validate();
            });

            // observe the other value and re-validate on change
            $scope.$watch(attrs.equals, function (val) {
                validate();
            });

            var validate = function () {
                // values
                var val1 = ngModel.$viewValue;
                var val2 = $scope.$eval(attrs.equals);
                
                if (angular.isEmpty(val2) || angular.isEmpty(val1)) {
                    
                    ngModel.$setValidity('equals', true);
                    return;
                }

                // set validity
                ngModel.$setValidity('equals', val1 === val2);
            };
        }
    };
});