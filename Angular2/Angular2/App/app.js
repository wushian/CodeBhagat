var app = angular.module('app', ['ngRoute', 'LocalStorageModule', 'ngSanitize', 'angular-loading-bar', 'ngToast']);


app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});


