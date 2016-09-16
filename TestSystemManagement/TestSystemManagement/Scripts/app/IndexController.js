﻿var app = angular.module('TestManagementSystem', ['ngRoute']);
app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $routeProvider
    .when('/about', {
        templateUrl: '/Template/About.html',
        controller: 'AboutController'
    })
    .when('/order/:id', {
        templateUrl: '/Template/Order.html',
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
}])
.controller('AboutController', function ($scope) {
    $scope.Message = "This is ABOUT page";
})
.controller('OrderController', function ($scope, $routeParams) {
    // $routeParams used for get query string value
    $scope.Message = "This is ORDER Page with query string id value " + $routeParams.id;
})
.controller('ErrorController', function ($scope) {
    $scope.Message = "404 Not Found!";
});