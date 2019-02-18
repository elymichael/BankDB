﻿angular
    .module('app')
    .component('cRegister', {
        templateUrl: 'scripts/app/Components/cRegister/c-register.html',
        require: {
            form: '^^form'
        },
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
                
                self.data.id = self.id;                
                $http.post(serviceBase + "User/", self.data).then(function (response) {
                    self.isLoading = false;
                    self.data = {};
                    self.callbackSuccess();
                },
                    function (error) {
                        self.isLoading = false;
                        self.message = appService.getError(error);
                    });
            };

            self.fillForm = function (_id) {
                $http.get(serviceBase + "User/Get/" + _id).then(function (response) {                
                    self.hasData = true;
                    self.data = response.data;
                },
                    function (error) {
                        self.message = appService.getError(error);
                    });
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