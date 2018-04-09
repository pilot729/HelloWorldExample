(function () {
    "use strict";

    var myApp1 = angular.module("myApp1");

    myApp1.controller("HomeController", [
        '$scope', '$http', 'busyService',
        function ($scope, $http, busyService) {
            $scope.busyService = busyService;
        }
    ]);

})();