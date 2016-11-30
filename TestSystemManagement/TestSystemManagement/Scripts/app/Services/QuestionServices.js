(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .factory('ImportQuestionService', ImportQuestionService)
        .factory('ImportTextQuestionService', ImportTextQuestionService)
        .factory('SearchQuestionService', SearchQuestionService);

    ImportQuestionService.$inject = ['$http', '$q'];
    ImportTextQuestionService.$inject = ['$http'];
    SearchQuestionService.$inject = ['$http'];

    function ImportTextQuestionService($http) {
        var importTextQuestionService = {};
        importTextQuestionService.NewTextQuestion = function (result) {
            return $http({
                url: '/api/TestDetails',
                method: 'POST',
                data: JSON.stringify(result),
                header: {
                    'content-type': 'application/json'
                }
            });
        };
        return importTextQuestionService;
    }

    function SearchQuestionService($http) {
        var searchQuestionService = {};
        searchQuestionService.FindQuestion = function (id) {
            return $http({
                url: '/api/TestDetails/' + id,
                method: 'GET',
                data: id,
                header: {
                    'content-type': 'application/json'
                }
            });
        };
        return searchQuestionService;
    }

    function ImportQuestionService($http, $q) {
        var importQeustionService = {};
        importQeustionService.UploadQuestion = function (file, extensionType) {
            var formData = new FormData();
            //append key value pair then submit to server
            formData.append('file', file);
            var url = '/TestDetail/UploadFile';
            var defer = $q.defer();
            $http.post(url,
                    formData,
                    {
                        headers: {
                            'Content-type': undefined
                        },
                        transformRequest: angular.identity
                    })
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function () {
                    defer.reject("File Upload Failed!");
                });
            return defer.promise;
        };
        return importQeustionService;
    }
})();