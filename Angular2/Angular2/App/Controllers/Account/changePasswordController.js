'use strict';
app.controller('changePasswordController', ['$scope', '$location', 'authService',
    function ($scope, $location, authService) {
    $scope.loginData = {
        oldPassword: "",
        newPassword: "",
        confirmPassword: ""
    };
    $scope.message = "";

        $(function() {
            formValidate();
        });

        // Validate Form Entries
    function formValidate() {
        var form = $('#changePasswordForm');
        form.validate({
            rules: {
                oldPassword: { required: true, maxlength: 10 },
                newPassword: { required: true, maxlength: 10 },
                ConfirmPassword: {
                    required: true, maxlength: 10,
                    equalTo: "#newPassword"
                }
            },
            highlight: function (element) {
                    $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function (element) {
                    $(element).closest('.form-group').removeClass('has-error');
            },
            errorElement: 'span',
            errorClass: 'help-block',
            errorPlacement: function (error, element) {
                error.insertAfter(element);
            }
        });
    };

    $scope.changePassword = function () {
        if ($('#changePasswordForm').valid()) {
            authService.changePassword($scope.loginData).then(function (response) {
                //alert("Password changed successfully!");

                $scope.loginData.oldPassword = "";
                $scope.loginData.newPassword = "";
                $scope.loginData.confirmPassword = "";
                window.location.href = "/#/";
           },
             function (err) {
                 $scope.message = "Incorrect password entry, please try again.";
             });
        } else {
            return false;
        }
    };

}]);
