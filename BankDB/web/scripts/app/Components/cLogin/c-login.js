angular
    .module('app')
    .component('cLogin', {
        templateUrl: 'scripts/app/Components/cLogin/c-login.html',
        require: {
            form: '^^form'
        },
        controller: function ($http, ngAuthSettings, authService, appService, $state, $http) {
            var self = this;
            var serviceBase = ngAuthSettings.apiServiceGlobalUri;

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
                    $http.get(serviceBase + 'Users/GetUserData').then(function (response) {                        
                        authService.setUserData(response.data);
                        self.isLoading = false;
                        self.callbackSuccess();
                    });
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