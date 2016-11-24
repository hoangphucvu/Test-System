(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .controller('IndexController', IndexController);

    IndexController.$inject = ['$scope', '$http'];

    function IndexController($scope, $http) {
        $scope.Logout = function () {
            window.location = "/Account/Login";
        };
    }
})();