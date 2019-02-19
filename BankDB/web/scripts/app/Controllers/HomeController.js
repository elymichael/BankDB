angular
    .module('app')
    .controller('HomeController', function HomeController($scope, authService, $state, ngAuthSettings, appService, $http, $filter) {
        $scope.message = "";
        $scope.id = 0;
        $scope.bankId = 0;
        $scope.branchId = 0;
        $scope.ratingId = 0;

        var serviceBase = ngAuthSettings.apiServiceGlobalUri;

        $scope.success = function () {            
            $scope.loadBanks();
            angular.element('.modal').modal('hide');
        };

        $scope.cancel = function () {      
            $scope.loadBanks();
            angular.element('.modal').modal('hide');
        };

        $scope.loadBanks = function () {
            $scope.Banks = [];            
            $http.get(serviceBase + 'Banks/').then(function (response) {                                    
                $scope.Banks = response.data;                
                angular.forEach($scope.Banks, function (bank) {
                    bank.rating = GetRating(bank.Branches);                    
                });
            }, function (error) {                
                $scope.message = appService.getError(error);
            });
        };

        function GetRating(branches) {            
            var rating = 0;
            if (branches.length > 0) {
                for (var i = 0; i < branches.length; i++) {
                    var branchRating = 0;
                    if (branches[i].Ratings.length > 0) {
                        for (var x = 0; x < branches[i].Ratings.length; x++) {
                            branchRating += branches[i].Ratings[x].Value;
                        }
                        branchRating = branchRating / branches[i].Ratings.length;
                    }
                    branches[i].rating = branchRating;
                    rating += branchRating;
                }
                rating = rating / branches.length;
            }
            return rating;
        };

        $scope.CheckUserRateBranch = function(x) {
            var flag = false;                  
            if (authService.authentication.isAuth) {
                if (authService.getUserData().Id > 0) {
                    var item = $filter('filter')(x.Ratings, { UserId: authService.getUserData().Id }, true);

                    if (item.length >= 1) {
                        flag = true;
                    }
                }
            }
            return flag;
        }
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