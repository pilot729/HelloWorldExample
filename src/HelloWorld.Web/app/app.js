(function () {
    "use strict";

    var myApp1 = angular.module("myApp1", ['ui.router', 'ui.bootstrap', 'ui.bootstrap.typeahead']);

    //this is supposed to increase debugging output: https://github.com/angular-ui/ui-router/wiki/Frequently-Asked-Questions#issue-im-getting-a-blank-screen-and-there-are-no-errors
    //myApp1.run(function ($rootScope) {
    //    $rootScope.$on("$stateChangeError", console.log.bind(console));
    //});
})();