(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .config(config)
        .controller('IndexController', IndexController)
        .controller('NewQuizController', NewQuizController);
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
            controller: 'ImportQuizController'
        })
        .when('/admin/quiz/new-quiz',
        {
            templateUrl: '/Template/NewQuiz.html',
            controller: 'NewQuizController'
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
    NewQuizController.$inject = ['$scope'];

    function IndexController($scope, $http) {
        $scope.Logout = function () {
            window.location = "/Account/Login";
        };
    }

    function NewQuizController($scope) {
        $scope.Message = "NewQuizController";
        $scope.number = 1;
        var i = 1;
        $scope.GenerateQuestion = function (totalQuestion) {
            var total = TryParseInt(totalQuestion, null);
            if (typeof (total) === 'number') {
                for (i = 1; i <= total; i++) {
                    $scope.number = i;
                    var parentElement = angular.element(document.querySelector('#cloneArea'));
                    var childElement = angular.element(document.querySelector('#cloneContent'));
                    parentElement.append(childElement.clone());
                }
            } else {
                alert('Vui lòng nhập số thích hợp');
                return false;
            }
        };
    }

    function TryParseInt(str, defaultValue) {
        var convertValue = defaultValue;
        if (str !== null) {
            if (str.length > 0) {
                if (!isNaN(str)) {
                    convertValue = parseInt(str);
                }
            }
        }
        return convertValue;
    }
})();