'use strict';
app.controller('forgotPasswordController', ['$scope', '$location',
'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        email: ""
    };

    $scope.message = "";

    $scope.forgotPassword = function () {
        
        
        authService.changePassword($scope.loginData).then(function (response) {
            $scope.message = "Password changed successfully!";
            $location.path('/#/Account/ForgotPasswordConfirmation');
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}]);
