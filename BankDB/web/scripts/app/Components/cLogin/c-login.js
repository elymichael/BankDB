angular
    .module('app')
    .component('cLogin', {
        templateUrl: 'scripts/app/Components/cLogin/c-login.html',
        require: {
            form: '^^form'
        },
        controller: function ($http, URI, authService, appService, $state) {
            var self = this;

            self.$onInit = function () {                
                initilize();
            };

            function initilize() {
                self.message = "";
                self.isLoading = false;                
                self.loginData = {
                    userName: "",
                    password: "",
                    rememberMe: false
                };
            };

            // Log in function
            self.login = function () {
                self.isLoading = true;
                authService.login(self.loginData).then(function (response) {                    
                    self.isLoading = false;
                },
                function (error) {
                    self.message = appService.getError(error);
                    self.isLoading = false;
                });
            };

            self.cancel = function () {
                self.callbackCancel();
            };
        },
        bindings: {            
            callbackSuccess: '&callbackSuccess',
            callbackCancel: '&callbackCancel'
        }
    });