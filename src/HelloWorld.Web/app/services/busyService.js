(function () {
    "use strict";

    var myApp1 = angular.module("myApp1");

    myApp1.factory('busyService', [
        '$http', '$timeout', function ($http, $timeout) {
            var _isBusy = false;
            var _isBusyTimer = null;
            var _hasError = false;

            return {
                set isBusy(val) {
                    if (val === false) {
                        if (_isBusyTimer != null) {
                            $timeout.cancel(_isBusyTimer);
                            _isBusyTimer = null;
                            _isBusy = false;
                        }
                    } else if (!_isBusyTimer && val === true) {
                        _isBusyTimer = $timeout(function () {
                            _isBusy = true;
                        }, 500);
                    }
                },
                get isBusy() {
                    return _isBusy;
                },
                set hasError(val) {
                    console.log("hasError" + val);
                    _hasError = val;
                    if (val) {
                        $('#theErrorDialog').show();
                    }
                },
                get hasError() {
                    return _hasError;
                },
                errorMessage: {},
                showException: function (data) {
                    this.errorMessage = data.Message + ": " + data.ExceptionMessage;
                    this.hasError = true;
                },
                showError: function (message) {
                    this.errorMessage = "ERROR: " + message;
                    this.hasError = true;
                }
            };
        }
    ]);

})();