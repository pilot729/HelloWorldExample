(function () {
    "use strict";

    var myApp1 = angular.module("myApp1");

    myApp1.config(['$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            //$urlRouterProvider.otherwise("/home");

            //$stateProvider
            //    .state('home', {
            //        url: "/home",
            //        templateUrl: "app/views/home.html",
            //        controller: "HomeController"
            //    });

            $stateProvider
                .state('helloWorld', {
                    url: "/helloWorld",
                    templateUrl: "app/views/helloWorld.html",
                    controller: "HelloWorldController",
                });
        }]);
})();