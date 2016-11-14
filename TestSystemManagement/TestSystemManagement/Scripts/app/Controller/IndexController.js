(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .config(config)
        .controller('IndexController', IndexController);

    IndexController.$inject = ['$scope', '$http'];

    function IndexController($scope, $http) {
        $scope.Logout = function () {
            window.location = "/Account/Login";
        };
    }
})();