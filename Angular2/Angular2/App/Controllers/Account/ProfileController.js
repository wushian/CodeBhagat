(function () {

    // Start Products List function
    var ListControllerId = 'profileList';
    angular.module('app').controller(ListControllerId, ['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'dataContext', 'notify', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, dataContext,notify) {
        var vm = this;

        //Search properties
        vm.profile = {
            FirstName: "",
            LastName: "",
            Email: "",
            UserName: "",
            Address: "",
            PhoneNumber: ""
        };
        $(function () {
            activate();
            formValidate();
        });
        function activate() {
            dataContext.get('api/Account/UserProfile').then(function (data) {
                vm.profile.FirstName = data.FirstName;
                vm.profile.LastName = data.LastName;
                vm.profile.Email = data.Email;
                vm.profile.UserName = data.UserName;
                vm.profile.Address = data.Address;
                vm.profile.PhoneNumber = data.PhoneNumber;
            });
        }

        // Validate Form Entries
        function formValidate() {
            var form = $('#userProfile');
            form.validate({
                rules: {
                    UserName: { required: true, maxlength: 50 },
                    FirstName: { required: true, maxlength: 50 },
                    LastName: { required: true, maxlength: 50 },
                    PhoneNumber: { required: true, maxlength: 14 }
                },
                highlight: function (element) {
                    $(element).closest('.col-xs-9').addClass('has-error');
                },
                unhighlight: function (element) {
                    $(element).closest('.col-xs-9').removeClass('has-error');
                },
                errorElement: 'span',
                errorClass: 'help-block',
                errorPlacement: function (error, element) {
                    error.insertAfter(element);
                }
            });
        };


        vm.save = function () {
            if ($('#userProfile').valid()) {
                dataContext.upDate("/api/Account/UpdateProfile", vm.profile).then(function (data) {
                    notify.showMessage('success', data.Message);
                    window.location.href = "/#/";
                });
            }
        };
    }

})();


