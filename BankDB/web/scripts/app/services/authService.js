'use strict';
angular
    .module('app')
    .factory('authService', ['$http', '$q', '$localStorage', '$sessionStorage', 'ngAuthSettings', '$filter', function (
        $http, $q, $localStorage, $sessionStorage, ngAuthSettings, $filter) {
        var serviceBase = ngAuthSettings.apiServiceBaseUri;
        var authServiceFactory = {};

        var _authentication = {
            isAuth: false,
            userName: "",
            useRefreshTokens: false,
            rememberMe: false
        };

        var _externalAuthData = {
            provider: "",
            userName: "",
            externalAccessToken: ""
        };

        var _saveRegistration = function (registration) {
            _logOut();
            return $http.post(serviceBase + 'account/register', registration).then(function (response) {
                return response;
            });
        };

        var _login = function (loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
            if (loginData.useRefreshTokens) {
                data = data + "&client_id=" + ngAuthSettings.clientId;
            }

            var deferred = $q.defer();
            $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
                var data = response.data;
                var _localauthData;

                if (loginData.useRefreshTokens) {
                    _localauthData = { token: data.access_token, userName: loginData.userName, refreshToken: data.refresh_token, useRefreshTokens: true };
                }
                else {
                    _localauthData = { token: data.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false };
                };

                if (loginData.rememberMe) {
                    $localStorage.authorizationData = _localauthData;
                } else {
                    $sessionStorage.authorizationData = _localauthData;
                };

                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;
                _authentication.useRefreshTokens = loginData.useRefreshTokens;
                _authentication.rememberMe = loginData.rememberMe;

                deferred.resolve(data);
            },
                function (err, status) {
                    _logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var _logOut = function () {
            delete $localStorage.authorizationData;
            delete $localStorage.currentUser;

            delete $sessionStorage.authorizationData;
            delete $sessionStorage.currentUser;

            _authentication.isAuth = false;
            _authentication.userName = "";
            _authentication.useRefreshTokens = false;
            _authentication.rememberMe = false;
        };

        var _fillAuthData = function () {
            var authData = $localStorage.authorizationData;
            if (!authData) { authData = $sessionStorage.authorizationData; };

            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                _authentication.useRefreshTokens = authData.useRefreshTokens;
                _authentication.rememberMe = authData.rememberMe;
            }
        };
        
        var _getUserData = function () {
            var userData = $localStorage.currentUser;
            if (!userData) { userData = $sessionStorage.currentUser; };

            return userData;
        };
        var _setUserData = function (data) {
            if ($localStorage.authorizationData) {
                $localStorage.currentUser = data;
            };

            if ($sessionStorage.authorizationData) {
                $sessionStorage.currentUser = data;
            };
        };

        var _getPermission = function (ID) {
            var userData = _getUserData();
            if (userData) {
                if (userData.tipoEntidad) {
                    if (userData.tipoEntidad.data) {
                        return $filter('filter')(userData.tipoEntidad.data, { nombre: ID })[0];
                    }
                }
            };

            return undefined;
        };


        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;        
        
        authServiceFactory.externalAuthData = _externalAuthData;        

        authServiceFactory.getUserData = _getUserData;
        authServiceFactory.setUserData = _setUserData;

        authServiceFactory.getPermission = _getPermission;

        return authServiceFactory;
    }]);