angular
    .module('app')
    .controller('HomeController', function HomeController($scope, authService, $state) {
        $scope.message = "";
        // Log out function.
        $scope.logOut = function () {
            authService.logOut();
            $state.go('in.login');
        }
        $scope.authentication = authService.authentication;
        if ($scope.authentication.isAuth)
            $scope.userData = authService.getUserData();
        
        if ($state.current) {
            if (!$scope.authentication.isAuth) {
                authService.logOut();
                $state.go('in.login');
            }
            else {
                if ($state.current.name !== "in.home") {
                    $state.go('in.home');
                }
            }
        }
    });