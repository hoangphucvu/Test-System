(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .config(config)
        .controller('AboutController', AboutController)
        .controller('OrderController', OrderController)
        .controller('ErrorController', ErrorController);

    function config($locationProvider, $routeProvider) {
        $routeProvider
        .when('/about', {
            templateUrl: '/Template/About.html',
            controller: 'AboutController'
        })
        .when('/upload/import-quiz', {
            templateUrl: '/Template/UploadQuestion.html',
            controller: 'OrderController'
        })
        .otherwise({   // This is when any route not matched
            templateUrl: '/Template/Error.html',
            controller: 'ErrorController'
        })
        //pretty url  // use the HTML5 History API
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }

    AboutController.$inject = ['$scope'];
    OrderController.$inject = ['$scope', '$routeParams'];
    ErrorController.$inject = ['$scope'];
    function AboutController($scope) {
        $scope.Message = "This is ABOUT page";
    }
    function OrderController($scope, $routeParams) {
        $scope.Message = "This is ORDER Page with query string id value " + $routeParams.id;
    }
    function ErrorController($scope) {
        $scope.Message = "404 Not Found!";
    }
})();