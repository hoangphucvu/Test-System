(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .config(config)
        .controller('IndexController', IndexController)
        .controller('ImportQuizController', ImportQuizController)
        .controller('NewQuizController', ImportQuizController);
    function config($locationProvider, $routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/Template/Index.html',
            controller: 'IndexController'
        })
        .when('/upload/import-quiz', {
            templateUrl: '/Template/UploadQuestion.html',
            controller: 'ImportQuizController'
        }).when('/upload/new-quiz', {
            templateUrl: '/Template/NewQuiz.html',
            controller: 'NewQuizController'
        })
       .otherwise({   // This is when any route not matched
           templateUrl: '/Template/Index.html',
           controller: 'IndexController'
       })
        //pretty url  // use the HTML5 History API
        //$locationProvider.html5Mode({
        //    //enabled: true,
        //    requireBase: false
        //}).hasPrefix('!');
    }

    IndexController.$inject = ['$scope', 'UserInfoService'];
    ImportQuizController.$inject = ['$scope'];
    NewQuizController.$inject = ['$scope'];
    function IndexController($scope, UserInfoService) {
        $scope.Message = UserInfoService.name;
    }
    function ImportQuizController($scope) {
        $scope.Message = "This is ImportQuizController Page with query string id value";
    }
    function NewQuizController($scope) {
        $scope.Message = "NewQuizController";
    }
})();