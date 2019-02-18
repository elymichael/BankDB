'use strict';
angular
    .module('app')
    .factory('authInterceptorService', function ($q, $injector, $location, $localStorage, $sessionStorage, $state) {
        var authInterceptorServiceFactory = {};
        var _request = function (config) {
            config.headers = config.headers || {};

            var authData = $localStorage.authorizationData;
            if (!authData) { authData = $sessionStorage.authorizationData; };

            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            };

            return config;
        }

        var _responseError = function (rejection) {
            if (rejection.status === 401) {
                var authService = $injector.get('authService');
                var authData = $localStorage.authorizationData;
                if (!authData) { authData = $sessionStorage.authorizationData; };

                if (authData) {
                    if (authData.useRefreshTokens) {                        
                        $location.path('/refresh');
                        return $q.reject(rejection);
                    }
                }
                authService.logOut();
                $state.go('in.login');
            }
            return $q.reject(rejection);
        }

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;
    });