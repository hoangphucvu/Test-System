(function () {
    'use strict';

    angular
        .module('TestSystemManagement')
        .factory('ImportQuestionService', ImportQuestionService)
        .factory('ImportTextQuestionService', ImportTextQuestionService)
        .factory('SearchQuestionService', SearchQuestionService)
        .factory('UpdateQuestionService', UpdateQuestionService)
        .factory('DeleteQuestionService', DeleteQuestionService);

    ImportQuestionService.$inject = ['$http', '$q'];
    ImportTextQuestionService.$inject = ['$http'];
    SearchQuestionService.$inject = ['$http'];
    UpdateQuestionService.$inject = ['$http'];
    DeleteQuestionService.$inject = ['$http'];

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
    function UpdateQuestionService($http) {
        var updateQuestionService = {};
        updateQuestionService.UpdateQuestion = function (id) {
            return $http({
                url: '/api/TestDetails/' + id,
                method: 'PUT',
                data: id,
                header: {
                    'content-type': 'application/json'
                }
            });
        };
        return updateQuestionService;
    }

    function DeleteQuestionService($http) {
        var deleteQuestionService = {};
        deleteQuestionService.DeleteTextQuestion = function (id) {
            return $http({
                url: '/api/TestDetails/' + id,
                method: 'DELETE',
                data: id,
                header: {
                    'content-type': 'application/json'
                }
            });
        };
        return deleteQuestionService;
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