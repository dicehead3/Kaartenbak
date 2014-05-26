app.service('loginService', ['$http', function($http) {

    return {
        login: function(user) {
            return $http.post('Login/Login', user);
        },
        register: function(user) {
            return $http.post('Login/Register', user);
        }
    };
}]);