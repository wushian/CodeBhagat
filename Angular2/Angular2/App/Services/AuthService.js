'use strict';
app.factory('authService', ['$http', '$q',
'localStorageService', 'notify', function ($http, $q, localStorageService, notify) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
    var serviceBase = '/';
    var authServiceFactory = {};
    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {
        _logOut();
        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            notify.showMessage('success', "Your account has been created successfully!");
            return response;
        }, function (data, status, headers, config) {
            notify.showMessage('danger', data.data.ModelState[""][0]);
            return deferred.reject(data);
        });
    };

    var _changePassword = function (loginData) {
        return $http.post(serviceBase + 'api/Account/ChangePassword', loginData).then(function (response) {
            notify.showMessage('success', "Your password has been changed successfully!");
            return response;
        }, function (data, status, headers, config) {
            notify.showMessage('danger', data.data.ModelState[""][0]);
            return deferred.reject(data);
        });
    };

    var _login = function (loginData) {
        var data = "grant_type=password&username=" +
        loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, {
            headers:
            { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (response) {
            localStorageService.set('authorizationData',
            { token: response.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;
            notify.showMessage('success', 'Welcome ' + loginData.userName + '!');

            deferred.resolve(response);
        }).error(function (err, status) {
            notify.showMessage('danger', err.error_descriptions);
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    var _fillAuthData = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.changePassword = _changePassword;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;


}]);