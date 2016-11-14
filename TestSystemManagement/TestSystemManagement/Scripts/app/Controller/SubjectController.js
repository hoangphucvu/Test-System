(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .controller('NewSubjectController', NewSubjectController);

    NewSubjectController.inject = ['$scope', '$http', 'NewSubjectService'];

    function NewSubjectController($scope, $http, NewSubjectService) {
        $scope.Submitted = false;
        $scope.IsFormValid = false;
        $scope.Loading = false;
        $scope.HideAddSubjectBtn = false;
        $scope.SubjectData = {
            SubjectName: '',
            SubjectCode: '',
            NoOfEasyQuestion: '',
            NoOfMediumQuestion: '',
            NoOfHardQuestion: '',
            TestDate: ''
        };

        $scope.$watch('AddNewSubjectForm.$valid', function (newVal) {
            $scope.IsFormValid = newVal;
        });

        $scope.AddNewSubject = function () {
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                $scope.Loading = true;
                $scope.HideAddSubjectBtn = true;
                NewSubjectService.NewSubject($scope.SubjectData).then(function (result) {
                    if (result.data === 'success') {
                        alert('Thêm môn thành công');
                        $scope.Loading = false;
                        $scope.HideAddSubjectBtn = false;
                    }
                    else {
                        alert('Vui lòng kiểm tra dữ liệu');
                        $scope.Loading = false;
                        $scope.HideAddSubjectBtn = false;
                    }
                });
            }
        };
    }
})();