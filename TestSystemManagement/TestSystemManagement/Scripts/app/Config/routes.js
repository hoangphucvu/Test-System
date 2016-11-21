(function () {
    'use strict';

    angular
        .module('routeApp', ['ngRoute'])
        .config(config);

    config.$inject = ['$locationProvider', '$routeProvider'];

    function config($locationProvider, $routeProvider) {
        $routeProvider
        .when('/',
        {
            templateUrl: '/Template/Index.html',
            controller: 'IndexController'
        })
        .when('/admin/subject',
        {
            templateUrl: '/Template/Subject.html'
        })
        .when('/admin/question',
        {
            templateUrl: '/Template/Question.html'
        })
        .otherwise({
            templateUrl: '/Template/Index.html',
            controller: 'IndexController'
        });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }
})();