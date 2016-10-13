(function () {
    'use strict';

    angular
    .module('TestManagementSystem')
    .controller('QuizController', QuizController)
    .controller('ImportQuestionController', ImportQuestionController)
    .factory('ImportQuestionService', ImportQuestionService);

    QuizController.$inject = ['$scope'];
    ImportQuestionController.inject = ['$scope', 'ImportQuestionService'];

    var extensionType = null;

    function QuizController($scope) {
        $scope.GenerateQuestion = function (totalQuestion) {
            var total = TryParseInt(totalQuestion, null);
            if (typeof (total) === 'number') {
                for (i = 1; i <= total; i++) {
                    $scope.number = i;
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

    function ImportQuestionController($scope, ImportQuestionService) {
        $scope.IsFileValid = false;
        $scope.HideUploadBtn = false;
        $scope.Loading = false;
        $scope.IsFormValid = false;
        $scope.Submitted = false;
        $scope.fileUpload = null;

        $scope.CheckFile = function (element) {
            $scope.$apply(function ($scope) {
                $scope.fileUpload = element.files[0];
                $scope.fileMessage = '';
                var fileName = $scope.fileUpload.name;
                console.log(fileName.length);
                var index = fileName.lastIndexOf(".");
                var strsubstring = fileName.substring(index, fileName.length);
                if (strsubstring === '.docx' ||
                    strsubstring === '.doc' ||
                    strsubstring === '.xls' ||
                    strsubstring === '.xlxs' ||
                    strsubstring === '.txt') {
                    $scope.IsFileValid = true;
                    extensionType = strsubstring;
                } else {
                    $scope.fileMessage = 'Should be .txt, .docx or .xxls';
                }
            });
        };

        $scope.$watch("ImportQuestionForm.$valid",
            function (isValid) {
                $scope.IsFormValid = isValid;
            });

        $scope.ImportQuestion = function () {
            $scope.Submitted = true;
            if ($scope.IsFileValid && $scope.IsFormValid) {
                $scope.HideUploadBtn = true;
                $scope.Loading = true;
                ImportQuestionService.UploadQuestion($scope.fileUpload, extensionType).then(function (data) {
                    alert(data.Message);
                    ClearForm();
                    $scope.HideUploadBtn = false;
                    $scope.Loading = false;
                    alert(data.Message);
                }, function (err) {
                    console.log('Error');
                });
            }
            else {
                $scope.Message = "All the fields are required.";
                $scope.HideUploadBtn = false;
                $scope.Loading = false;
            }
        }

        function ClearForm() {
            angular.forEach(angular.element("input[type='file']"),
                function (inputElement) {
                    angular.element(inputElement).val(null);
                });
            //clear all data in form
            $scope.ImportQuestionForm.$setPristine();
            $scope.Submitted = false;
        }
    }

    function ImportQuestionService($http, $q) {
        var importQeustionService = {};
        importQeustionService.UploadQuestion = function (file, extensionType) {
            var formData = new FormData();
            //append key value pair then submit to server
            formData.append('file', file);
            var url = null;
            if (extensionType === '.txt') {
                url = 'http://localhost:2151/TestDetail/UploadTextFile';
            }

            var defer = $q.defer();
            $http.post(url, formData, {
                headers: { 'Content-type': undefined },
                transformRequest: angular.identity
            }).
            success(function (data) {
                defer.resolve(data);
            }).
            error(function () {
                defer.reject("File Upload Failed!");
            });
            return defer.promise;
        }
        return importQeustionService;
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