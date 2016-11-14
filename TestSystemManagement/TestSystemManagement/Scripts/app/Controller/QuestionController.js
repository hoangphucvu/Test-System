(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .controller('QuizController', QuizController)
        .controller('ImportQuestionController', ImportQuestionController)
        .factory('ImportQuestionService', ImportQuestionService)
        .factory('ImportTextQuestionService', ImportTextQuestionService);

    QuizController.$inject = ['$scope', 'ImportTextQuestionService'];
    ImportQuestionController.inject = ['$scope', 'ImportQuestionService'];

    var extensionType = null;

    function QuizController($scope, ImportTextQuestionService) {
        $scope.QuizFormSubmitted = false;
        $scope.IsQuizFormFormValid = false;
        $scope.ImportTextData = {
            Question: '',
            AnswerA: '',
            AnswerB: '',
            AnswerC: '',
            AnswerD: '',
            CorrectAnswer: '',
            TypeOfQuestion: '',
            Point: ''
        };

        $scope.$watch('NewTextForm.$valid', function (newValue) {
            $scope.IsQuizFormFormValid = true;
        });
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

        $scope.ImportTextQuiz = function () {
            $scope.QuizFormSubmitted = true;
            var data = $("#newTextForm").serializeArray();
            //var result = {};
            var result = data.map(function (formData) { return formData.value; });
            //$.each(data,
            //    function() {
            //        result[this.name] = this.value;
            //    });
            console.log(result);
            if ($scope.IsQuizFormFormValid) {
                ImportTextQuestionService.NewTextQuestion(result).then(function (result) {
                    console.log(result);
                    if (result.status === 200) {
                        Materialize.toast('Upload thành công', 4000);
                    }
                    Materialize.toast('Upload không thành công', 4000);
                });
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
        $scope.Message = null;
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
                    strsubstring === '.xlsx' ||
                    strsubstring === '.txt') {
                    $scope.IsFileValid = true;
                    extensionType = strsubstring;
                } else {
                    $scope.fileMessage = 'FIle phải có định dạng .txt, .docx or .xlsx';
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
                ImportQuestionService.UploadQuestion($scope.fileUpload, extensionType).then(function (result) {
                    console.log(result);
                    if (result === true) {
                        //$scope.Message = "Upload thành công";
                        ClearForm();
                        Materialize.toast('Upload thành công', 4000);
                    } else {
                        $scope.Message = "Có lỗi xảy ra vui lòng thử lại";
                        $scope.HideUploadBtn = false;
                        $scope.Loading = false;
                    }
                }, function (err) {
                    $scope.Message = "Có lỗi xảy ra vui lòng thử lại";
                });
            } else {
                $scope.Message = "Vui lòng chọn file";
                $scope.HideUploadBtn = false;
                $scope.Loading = false;
            }
        };
    }

    function ClearForm() {
        angular.forEach(angular.element("input[type='file']"),
            function (inputElement) {
                angular.element(inputElement).val(null);
            });
        //clear all data in form
        $scope.ImportQuestionForm.$setPristine();
        $scope.Submitted = false;
        $scope.Message = null;
        $scope.HideUploadBtn = false;
        $scope.Loading = false;
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