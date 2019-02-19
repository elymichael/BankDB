angular
    .module('app')
    .controller('HomeController', function HomeController($scope, authService, $state, ngAuthSettings, appService, $http) {
        $scope.message = "";
        $scope.id = 0;
        var serviceBase = ngAuthSettings.apiServiceGlobalUri;

        $scope.success = function () {
            angular.element('.modal').modal('hide');
        };

        $scope.cancel = function () {
            angular.element('.modal').modal('hide');
        };

        $scope.loadBanks = function () {
            $scope.Banks = [];            
            $http.get(serviceBase + 'Banks/').then(function (response) {                                    
                $scope.Banks = response.data;                
                //angular.forEach($scope.Banks, function (value) {
                    
                //});
            }, function (error) {                
                $scope.message = appService.getError(error);
            });
        };

        // Log out function.
        $scope.logOut = function () {
            authService.logOut();
        }
        $scope.authentication = authService.authentication;
        if ($scope.authentication.isAuth)
            $scope.userData = authService.getUserData();

        if ($state.current) {
            if (!$scope.authentication.isAuth) {
                authService.logOut();
            }
            if ($state.current.name !== "in.home") {
                $state.go('in.home');
            }
        }        
        $scope.loadBanks();
    });