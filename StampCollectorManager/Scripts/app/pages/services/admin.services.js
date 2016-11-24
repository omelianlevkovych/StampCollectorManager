(function (angular) {
    'use strict';
    angular
        .module('adminModule')
        .factory('adminService', adminService);
    
    adminService.$inject = ['$http'];

    function adminService($http) {
        var service = {
            getStampCollectors: getStampCollectors

        };
        return service;

        function getStampCollectors() {
            var promise = $http.get('/Admin/GetStampCollectors');
            return promise;
        };

    }
})(angular);