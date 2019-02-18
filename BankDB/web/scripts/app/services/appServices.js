angular
    .module('app')
    .service('appService', ['$http', '$q', function ($http, $q)  {
        this.getError = function (error) {
            var errorMessage;

            if (error) {
                if (error.Message) {
                    errorMessage = error.Message;
                }

                if (error.data) {
                    if (error.data.Message) {
                        errorMessage = error.data.Message + ' ' + parseErrors(error.data).join('');
                    }

                    if (error.data.error) {
                        errorMessage = error.data.error;
                    }

                    if (error.data.error_description) {
                        errorMessage = errorMessage + ' ' + error.data.error_description;
                    }

                    if (error.statusText.length > 0) {
                        errorMessage = error.statusText + ' ' + errorMessage;
                    }
                }

                if (errorMessage === undefined && error.statusText.length > 0) {
                    errorMessage = error.statusText;
                }
            }
            return errorMessage;
        };

        function parseErrors(response) {
            var errors = [];
            for (var key in response.ModelState) {
                for (var i = 0; i < response.ModelState[key].length; i++) {
                    errors.push(response.ModelState[key][i]);
                }
            }
            return errors;
        };
    }]);