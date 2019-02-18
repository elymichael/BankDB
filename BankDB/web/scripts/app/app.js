angular.module('app', ['ngRoute',
    'ui.router',
    'ngStorage',
    'angularUtils.directives.dirPagination',
    'ngSanitize'
]);

angular
    .module('app')
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.hashPrefix('');
    }]);


angular
    .module('app')
    .config(function ($stateProvider, $routeProvider) {
        $stateProvider
            .state('in', {
                url: '',
                abstract: true,
                views: {
                    'header': {
                        templateUrl: 'include/header.html', controller: 'MenuController'
                    },
                    'content': {
                        template: '<div ui-view></div>'
                    },
                    'footer': {
                        templateUrl: 'include/footer.html', controller: 'MenuController'
                    }
                }                
            })
            .state('in.home', {
                url: '/', templateUrl: 'views/home.html', controller: 'HomeController'
            })

        $routeProvider.otherwise(function ($injector) {
            var $state = $injector.get("$state");
            $state.go('in.home');
        });
    });


angular
    .module('app')
    .run(function (authService, $rootScope, $state, $stateParams) {
        authService.fillAuthData();
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;
    });


angular
    .module('app')
    .constant('ngAuthSettings', {
        apiServiceBaseUri: '/',
        apiServiceGlobalUri: '/api/',
        clientId: 'ngAuthApp'
    });

angular
    .module('app')
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });

angular
    .module('app')
    .run(['authService', function (authService) {
        authService.fillAuthData();
    }]);
