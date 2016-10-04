(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .controller('LoginController', LoginController)
        .factory('LoginService', LoginService)
        .factory('UserInfoService', UserInfoService);

    LoginController.$inject = ['$scope', '$location', 'LoginService'];

    function LoginController($scope, $location, LoginService) {
        $scope.title = 'Hệ Thống Quản Lý Đề Thi';
        $scope.IsLogging = false;
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
            $scope.IsLogging = true;
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                $scope.ShowLoading = true;
                $scope.HideLoginBtn = true;
                LoginService.GetLogin($scope.LoginData).then(function (result) {
                    if (result.data === true) {
                        $scope.IsLogin = true;
                        window.location.href = "/Admin/Index";
                    }
                    if (result.data === false) {
                        $scope.Message = 'Vui lòng kiểm tra tên đăng nhập vả mật khẩu';
                        Materialize.toast('Vui lòng kiểm tra tên đăng nhập vả mật khẩu', 4000);
                        $scope.ShowLoading = false;
                        $scope.HideLoginBtn = false;
                    }
                });
            }
        }
    }

    function LoginService($http) {
        var factoryService = {};
        factoryService.GetLogin = function (result) {
            return $http({
                url: '/Account/Login',
                method: 'POST',
                data: JSON.stringify(result),
                header: { 'content-type': 'application/json' }
            });
        }
        return factoryService;
    }

    function UserInfoService($scope) {
        var userInfo = {};
        userInfo.name = $scope.LoginData.Username;
        return userInfo;
    }
})();