angular
    .module('app')
    .controller('HomeController', function HomeController($scope, authService, $state, ngAuthSettings) {
        $scope.message = "";
        $scope.id = 0;

        $scope.success = function () {
            
        };

        $scope.cancel = function () {
            
        };
        
        $scope.loadBanks = function () {
            $scope.baBanks = [];
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