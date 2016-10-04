(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .config(config)
        .controller('IndexController', IndexController)
        .controller('ImportQuizController', ImportQuizController)
        .controller('NewQuizController', NewQuizController);
    function config($locationProvider, $routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/Template/Index.html',
            controller: 'IndexController'
        })
        .when('/admin/upload/import-quiz', {
            templateUrl: '/Template/UploadQuestion.html',
            controller: 'ImportQuizController'
        }).when('/admin/upload/new-quiz', {
            templateUrl: '/Template/NewQuiz.html',
            controller: 'NewQuizController'
        })
       .otherwise({
           templateUrl: '/Template/Index.html',
           controller: 'IndexController'
       })
        //pretty url  // use the HTML5 History API
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }

    IndexController.$inject = ['$scope', '$http'];
    ImportQuizController.$inject = ['$scope'];
    NewQuizController.$inject = ['$scope'];
    function IndexController($scope, $http) {
        $scope.Logout = function () {
            return $http({
                url: '/Admin/Logout',
                method: 'GET'
            });
        }
    }
    function ImportQuizController($scope) {
    }
    function NewQuizController($scope) {
        $scope.Message = "NewQuizController";
        $scope.GenerateQuestion = function (totalQuestion) {
            var total = TryParseInt(totalQuestion, null);
            if (typeof (total) === 'number') {
                for (i = 0; i < total; i++) {
                    var parentElement = angular.element(document.querySelector('#cloneArea'));
                    var childElement = angular.element(document.querySelector('#cloneContent'));
                    parentElement.append(childElement.clone());
                }
            }
            else {
                alert('Vui lòng nhập số thích hợp');
                return false;
            }
        };
    }

    function TryParseInt(str, defaultValue) {
        var convertValue = defaultValue;
        if (str != null) {
            if (str.length > 0) {
                if (!isNaN(str)) {
                    convertValue = parseInt(str);
                }
            }
        }
        return convertValue;
    }
})();