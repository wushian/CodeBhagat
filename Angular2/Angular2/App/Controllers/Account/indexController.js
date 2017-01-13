'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    //$(function () {
    //    authService.fillAuthData();
    //});


    $scope.logOut = function () {
        // On Logout, Go to Login page
        authService.logOut();
        $location.path('/login');
    }

    // Get Authentication Data
    $scope.authentication = authService.authentication;

    // If Authenticated, Go to Home Page Else Login Page
    if ($scope.authentication.isAuth)
        $location.path('/');
    else
        $location.path('/login');

}]);