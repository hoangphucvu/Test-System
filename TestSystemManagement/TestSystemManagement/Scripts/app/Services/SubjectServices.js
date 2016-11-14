(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .factory('NewSubjectService', NewSubjectService);

    NewSubjectService.$inject = ['$http'];

    function NewSubjectService($http) {
        var newSubjectService = {};
        newSubjectService.NewSubject = function (result) {
            return $http({
                url: 'http://localhost:2151/api/Subject',
                method: 'POST',
                data: JSON.stringify(result),
                header: {
                    'content-type': 'application/json'
                }
            });
        };
        return newSubjectService;
    }
})();