angular
    .module('app')
    .component('cRating', {
        templateUrl: 'scripts/app/Components/cRating/c-rating.html',        
        controller: function ($http, ngAuthSettings, authService, appService, $state) {
            var self = this;
            var serviceBase = ngAuthSettings.apiServiceGlobalUri;

            self.$onInit = function () {
                $timeout(function () {
                    if (!self.id)
                        self.id = "0";
                    
                    if (!self.parentId)
                        self.parentId = "0";

                    initilize();
                    }, 0);
            };

            function initilize() {
                self.message = "";
                self.isLoading = false;
                self.data = {
                    Value: 1,
                    BranchId: self.parentId
                };
                debugger;
                self.hasData = false;
            };

            self.save = function () {
                self.isLoading = true;
                debugger;
                self.data.Id = self.id;
                self.data.BranchId = self.parentId;
                self.data.UserId = authService.getUserData().Id;
                $http.post(serviceBase + "Ratings/", JSON.stringify(self.data), {
                    headers: { 'Content-Type': 'application/json' }
                }).then(function (response) {
                    self.isLoading = false;
                    self.data = {};
                    self.callbackSuccess();
                },
                    function (error) {
                        self.isLoading = false;
                        self.message = appService.getError(error);
                    });
            };

            self.cancel = function () {
                self.callbackCancel();
            };
        },
        bindings: {
            id: '<?',
            parentId:'=?',
            callbackSuccess: '&callbackSuccess',
            callbackCancel: '&callbackCancel'
        }
    });