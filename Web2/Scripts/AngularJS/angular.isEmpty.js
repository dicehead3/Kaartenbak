if (!angular.isEmpty) {
    angular.isEmpty = function (val) {
        return $.trim(val).length == 0;
    };
}