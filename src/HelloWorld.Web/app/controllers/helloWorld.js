(function () {
    "use strict";

    var myApp1 = angular.module("myApp1");

    myApp1.controller('HelloWorldController', ['$scope', '$http', 'busyService', '$rootScope',
        function ($scope, $http, busyService, $rootScope) {

            $rootScope.pageTitle = "Hello World";

            var vm = $scope.vm = {};

            var id = 1;

            busyService.isBusy = true;

            $http({
                method: 'GET',
                url: 'api/greeting/' + id
            }).then(function successCallback(response) {
                vm.greeting = response.data;
            }, function errorCallback(response) {
                busyService.showException(response.data);
            }).then(function () {
                busyService.isBusy = false;
            });
        }
    ]);
})();
