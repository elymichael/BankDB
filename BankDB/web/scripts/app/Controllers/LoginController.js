angular
    .module('app')
    .controller('LoginController', function ($scope, authService, appService, $state) {
        $scope.message = "";
        $scope.isLoading = false;
        $scope.loginData = {
            userName: "",
            password: "",
            rememberMe: false
        };

        $scope.login = function () {
            $scope.isLoading = true;
            authService.login($scope.loginData).then(function (response) {
                $state.go('in.home');
                $scope.isLoading = false;
            },
                function (error) {
                    $scope.message = appService.getError(error);
                    $scope.isLoading = false;
                });
        };


    })