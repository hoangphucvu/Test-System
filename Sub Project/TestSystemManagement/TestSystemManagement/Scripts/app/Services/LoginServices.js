(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .factory('LoginService', LoginService);

    LoginService.$inject = ['$http'];

    function LoginService($http) {
        var factoryService = {};
        factoryService.GetLogin = function (result) {
            return $http({
                url: '/Account/Login',
                method: 'POST',
                data: JSON.stringify(result),
                header: {
                    'content-type': 'application/json'
                }
            });
        };
        return factoryService;
    }
})();