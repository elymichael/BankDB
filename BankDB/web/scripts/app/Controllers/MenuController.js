angular
    .module('app')
    .controller('MenuController', function MenuController($scope, authService) {
        $scope.message = "";
        
        $scope.success = function () {            
            angular.element('.modal').modal('hide');
        };

        $scope.cancel = function () {            
            angular.element('.modal').modal('hide');
        };
    });