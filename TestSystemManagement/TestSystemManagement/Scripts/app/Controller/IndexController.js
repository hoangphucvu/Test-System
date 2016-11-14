(function() {
    'use strict';

    angular
        .module('TestManagementSystem')
        .controller('IndexController', IndexController);

    IndexController.$inject = ['$scope', '$http'];

    function IndexController($scope, $http) {
        $scope.Logout = function() {
            window.location = "/Account/Login";
        };
    }
})();