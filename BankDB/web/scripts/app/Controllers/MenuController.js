angular
    .module('app')
    .controller('MenuController', function MenuController($scope, authService) {
        $scope.message = "";
        $scope.menuVisibility = {};

        initialize();

        function initialize() {
            if (authService.authentication.isAuth) {
                $scope.userData = authService.getUserData();

                if ($scope.userData) {
                    if ($scope.userData.tipoEntidad) {
                        var data = $scope.userData.tipoEntidad.data;
                        for (i = 0; i < data.length; i++) {
                            $scope.menuVisibility[data[i].nombre.replace(/ /g, "")] = (data[i].activo && data[i].roles.view);
                        };
                    };
                };
            };

        };
    });