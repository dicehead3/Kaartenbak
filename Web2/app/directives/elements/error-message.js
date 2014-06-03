app.directive('error', [function () {

    return {
        restrict: 'E',
        scope: {
            text: '=',
            show: '=',
            fixedText: '@'
        },
        template: '<span class="alert alert-error display-message">{{text}}{{fixedText}}</span>',
        replace: true,
        link: function ($scope, $element, attrs) {
            console.log('hier0', $scope, $element, attrs);
            if (attrs.show) {
                console.log('hier1');
                $element.hide();
                console.log('hier2');
                $scope.$watch('show', function () {

                    if ($scope.show) {
                        console.log('hier3');
                        $element.show();
                    } else {
                        console.log('hier4');
                        $element.hide();
                    }

                }, true);
            } else {
                console.log('hier5');
                $element.show();
            }
        }
    };
}]);