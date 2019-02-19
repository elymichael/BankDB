angular
    .module('app')
    .directive('cGridColumn', function ($compile) {
        return {
            restrict: 'E',
            templateUrl: 'scripts/app/components/cGridColumns/c-grid-column.html',
            replace: true,
            scope: {
                title: '@title',
                name: '@name'
            },
            controller: ['$scope', function OrderBy($scope) {
                var mainScope = $scope.$parent.$parent;
                $scope.orderClass = '';

                $scope.orderByMe = function (x) {
                    $scope.orderClass = '';
                    if (mainScope.myOrderBy === x) {
                        $scope.orderClass = 'dropup';
                        x = '-' + x;
                    }
                    mainScope.myOrderBy = x;
                };
            }],
            link: function (scope, element, attrs) {
                $compile(element.contents())(scope.$new());
            }
        }
    });