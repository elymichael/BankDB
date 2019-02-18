angular
    .module('app')
    .controller('HomeController', function HomeController($scope, authService, $state) {
        $scope.message = "";

        $scope.success = function () {
            
        };

        $scope.cancel = function () {
            
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
    });