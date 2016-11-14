(function () {
    'use strict';

    angular
        .module('app')
        .factory('LoginServices', LoginServices);

    LoginServices.$inject = ['$http'];

    function LoginService($http) {
        var factoryService = {};
        factoryService.GetLogin = function (result) {
            return $http({
                url: '/Account/Login',
                method: 'POST',
                data: JSON.stringify(result),
                header: { 'content-type': 'application/json' }
            });
        };
        return factoryService;
    }
})();