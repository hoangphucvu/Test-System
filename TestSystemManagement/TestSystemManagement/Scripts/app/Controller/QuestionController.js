(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .controller('QuizController', QuizController)
        .controller('ImportQuestionController', ImportQuestionController);

    QuizController.$inject = ['$scope', 'ImportTextQuestionService', 'SearchQuestionService', 'UpdateQuestionService', 'DeleteQuestionService'];
    ImportQuestionController.inject = ['$scope', 'ImportQuestionService'];

    var extensionType = null;

    function QuizController($scope, ImportTextQuestionService, SearchQuestionService, UpdateQuestionService, DeleteQuestionService) {
        $scope.QuizFormSubmitted = false;
        $scope.IsQuizFormFormValid = false;
        $scope.ImportTextData = {
            Question: '',
            AnswerA: '',
            AnswerB: '',
            AnswerC: '',
            AnswerD: '',
            CorrectAnswer: '',
            TestChildSubjectId: '',
            TypeOfQuestion: '',
            Point: ''
        };

        $scope.$watch('NewTextForm.$valid', function (newValue) {
            $scope.IsQuizFormFormValid = newValue;
        });

        $scope.GenerateQuestion = function (totalQuestion) {
            var total = TryParseInt(totalQuestion, null);
            var i = 1;
            if (typeof (total) === 'number') {
                for (i; i <= total; i++) {
                    $scope.number = i;
                    var parentElement = angular.element(document.querySelector('#cloneArea'));
                    var childElement = angular.element(document.querySelector('.cloneContent'));
                    parentElement.append(childElement.clone());
                }
            } else {
                alert('Vui lòng nhập số thích hợp');
                return false;
            }
        };

        $scope.ImportTextQuiz = function () {
            $scope.QuizFormSubmitted = true;
            var checkboxData = [];
            var list = [];
            $.each($("input[name='CorrectAnswer']:checked"),
                function () {
                    checkboxData.push($(this).val());
                });

            var data = {
                Question: CKEDITOR.instances['Question'].getData(),
                AnswerA: CKEDITOR.instances['AnswerA'].getData(),
                AnswerB: CKEDITOR.instances['AnswerB'].getData(),
                AnswerC: CKEDITOR.instances['AnswerC'].getData(),
                TestChildSubjectId: $("#TestChildSubjectId").val(),
                AnswerD: CKEDITOR.instances['AnswerD'].getData(),
                CorrectAnswer: checkboxData,
                TypeOfQuestion: $("#TypeOfQuestion option:selected").val()
            };
            list.push(data);

            var jsonData = JSON.stringify(list);
            console.log(checkboxData);
            ImportTextQuestionService.NewTextQuestion(jsonData).then(function (result) {
                if (result.data === "success") {
                    alert("Thêm thành công");
                }
                else alert("Có lỗi xảy ra vui lòng thử lại");
            });
        };

        $scope.searchQuestion = function () {
            $scope.showSearchTable = false;
            var testChildSubjectId = $scope.TestChildSubjectId;
            SearchQuestionService.FindQuestion(testChildSubjectId)
                .then(function (result) {
                    console.log(result.data.Data);
                    $scope.searchData = result.data.Data;
                    $scope.showSearchTable = true;
                });
        }

        $scope.UpdateQuestion = function (id) {
            console.log(id);
            UpdateQuestionService.UpdateQuestion(id)
               .then(function (result) {
               });
        }
        $scope.DeleteQuestion = function (id) {
            console.log(id);
            DeleteQuestionService.DeleteTextQuestion(id).then(function (result) {
                if (result.data === "success") {
                    alert("Xóa thành công");
                    $scope.searchQuestion();
                }
                else alert("Có lỗi xảy ra vui lòng thử lại");
            });
        }
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
                        //ClearForm();
                        Materialize.toast('Upload thành công', 4000);
                        $scope.HideUploadBtn = false;
                        $scope.Loading = false;
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

    function ClearForm($scope) {
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