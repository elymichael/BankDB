angular
    .module('app')
    .component('cBank', {
        templateUrl: 'scripts/app/Components/cBank/c-bank.html',
        controller: function ($http, ngAuthSettings, authService, appService, $state) {
            var self = this;
            var serviceBase = ngAuthSettings.apiServiceGlobalUri;

            self.$onInit = function () {
                if (!self.id)
                    self.id = "0";

                initilize();
            };

            function initilize() {
                self.message = "";
                self.isLoading = false;
                self.data = {};
                self.hasData = false;

                self.fillForm(self.id);
            };

            self.save = function () {
                self.isLoading = true;

                self.data.Id = self.id;
                self.data.UserId = authService.getUserData().Id;
                debugger;
                $http.post(serviceBase + "Banks/", JSON.stringify(self.data), {
                    headers: { 'Content-Type': 'application/json' }
                }).then(function (response) {
                    self.isLoading = false;
                    self.data = {};
                    self.callbackSuccess();
                }, function (error) {
                    self.isLoading = false;
                    self.message = appService.getError(error);
                });
            };

            self.fillForm = function (_id) {
                //appService.getData("Bank", "Get", _id).then(function (response) {
                //    self.hasData = true;
                //    self.data = response.data;
                //},
                //    function (error) {
                //        self.message = appService.getError(error);
                //    });
            };

            self.cancel = function () {
                self.callbackCancel();
            };
        },
        bindings: {
            id: '<?',
            callbackSuccess: '&callbackSuccess',
            callbackCancel: '&callbackCancel'
        }
    });