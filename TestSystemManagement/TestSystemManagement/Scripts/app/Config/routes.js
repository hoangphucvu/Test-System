(function () {
    'use strict';

    angular
        .module('routeApp')
        .config('routes', routes);

    config.$inject = ['$locationProvider', '$routeProvider'];

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
})();