(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .config(config)
        .controller('IndexController', IndexController);

    function config($locationProvider, $routeProvider) {
        $routeProvider
        .when('/',
        {
            templateUrl: '/Template/Index.html',
            controller: 'IndexController'
        })
        .when('/admin/subject/new-subject',
        {
            templateUrl: '/Template/NewSubject.html',
            controller: 'NewSubjectController'
        })
        .when('/admin/quiz/import-quiz',
        {
            templateUrl: '/Template/UploadQuestion.html',
            controller: 'ImportQuestionController'
        })
        .when('/admin/quiz/new-quiz',
        {
            templateUrl: '/Template/NewQuiz.html',
            controller: 'QuizController'
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

    IndexController.$inject = ['$scope', '$http'];

    function IndexController($scope, $http) {
        $scope.Logout = function () {
            window.location = "/Account/Login";
        };
    }
})();