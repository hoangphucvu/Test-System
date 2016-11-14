(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .controller('NewSubjectController', NewSubjectController)
        .factory('NewSubjectService', NewSubjectService);

    NewSubjectController.inject = ['$scope', '$http', 'NewSubjectService'];

    function NewSubjectController($scope, $http, NewSubjectService) {
        $scope.Submitted = false;
        $scope.IsFormValid = false;

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
                NewSubjectService.NewSubject($scope.SubjectData).then(function (result) {
                    console.log(result);
                    if (result.data === 'success') {
                        alert('Thêm môn thành công');
                    }
                    else {
                        alert('Vui lòng kiểm tra dữ liệu');
                    }
                });
            }
        };
    }

    function NewSubjectService($http) {
        var newSubjectService = {};
        newSubjectService.NewSubject = function (result) {
            return $http({
                url: 'http://localhost:2151/api/Subject',
                method: 'POST',
                data: JSON.stringify(result),
                header: { 'content-type': 'application/json' }
            });
        };
        return newSubjectService;
    }
})();