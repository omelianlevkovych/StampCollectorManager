(function (angular) {
    'use strict';
    angular
        .module('adminModule')
        .controller('adminController', AdminController);

    AdminController.$inject = ['adminService'];

    function AdminController(adminService) {
        var vm = this;
        vm.stampCollectors = [];

        init();

        function init() {
            var adminPromise = adminService.getStampCollectors();
            adminPromise.then(function (response) {
                vm.stampCollectors.push.apply(vm.stampCollectors, response.data);
            });
        };
    };
})(angular);