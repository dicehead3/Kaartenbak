app.service('userService', ['$http', function($http) {

    return {
        login: function(user) {
            return $http.post('Login/Login', user);
        }
    };
}]);