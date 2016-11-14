(function () {
    'use strict';

    angular
        .module('TestManagementSystem')
        .factory('SubjectServices', NewSubjectService);

    NewSubjectService.$inject = ['$http'];

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