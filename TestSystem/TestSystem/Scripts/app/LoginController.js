(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .controller('LoginController', LoginController)
        .factory('LoginService', LoginService);

    LoginController.$inject = ['$scope', 'LoginService'];

    function LoginController($scope, LoginService) {
        $scope.title = 'Hệ Thống Quản Lý Đề Thi';
        $scope.IsLogin = false;
        $scope.Submitted = false;
        $scope.IsFormValid = false;

        $scope.LoginData = {
            Username: '',
            Password: ''
        };

        $scope.$watch('LoginForm.$valid', function (newVal) {
            $scope.IsFormValid = newVal;
        });

        $scope.Login = function () {
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                LoginService.GetLogin($scope.LoginData).then(function (result) {
                    if (result.data.Username != null) {
                        $scope.IsLogin = true;
                        alert('Login success');
                    }
                    else {
                        alert('Login failed');
                    }
                });
            }
        }
    }

    function LoginService($http) {
        var factoryService = {};
        factoryService.GetLogin = function (result) {
            return $http({
                url: '/Admin/Login',
                method: 'POST',
                data: JSON.stringify(result),
                header: { 'content-type': 'application/json' }
            });
        }
        return factoryService;
    }
})();