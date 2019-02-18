angular
    .module('app')
    .directive('cdContainer', function () {
        return {
            restrict: 'E',
            transclude: true,
            templateUrl: 'scripts/app/directives/cdContainer/cd-container.html',
            replace: true,
            scope: {
                title: '@title',
                message: '<message'
            }
        }
    });