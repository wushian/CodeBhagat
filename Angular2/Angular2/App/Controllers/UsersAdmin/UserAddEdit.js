(function () {
    // User Add/Edit controller
    var addEditControllerId = 'UserAddEdit';
    angular.module('app').controller(addEditControllerId,
		['$scope', '$location', '$routeParams', 'dataContext', '$route', 'notify', UsersAddEdit]);

    function UsersAddEdit($scope, $location, $routeParams, dataContext, $route, notify) {
        var vm = this;
        vm.title = "Add User";
        vm.isNew = true;
        vm.isRoleAdd = isRoleAdd;
        vm.save = Save;
        vm.AllRoles = [];
        vm.selectedRoles = [];

        // User object
        vm.User = {
            Id: "",
            UserName: "",
            Email: "",
            FirstName: "",
            LastName: "",
            Address: "",
            City: "",
            State: "",
            PostalCode: "",
            PhoneNumber: "",
            ConfirmPassword: ""
        };

        activate();

        function activate() {
            formValidate();

            dataContext.get('/RolesAdmin/GetRoles').then(function (data) {
                vm.AllRoles = data.roles;
            }).then(function () {
            if ($routeParams.UserId != undefined && $routeParams.UserId != "" && $routeParams.UserId != null) {
                vm.Title = "Edit User";
                vm.isNew = false;
                dataContext.getById("/UsersAdmin/Details/" + $routeParams.UserId).then(function (data) {
                    $.grep(data.user.Roles.split(','), function (a, i) {
                        if (a != null && a != "") {
                            $("#" + a).prop("checked", true);
                                isRoleAdd($("#" + a).attr("data-role-name"));
                        }
                    });

                    vm.User.Id = data.user.Id;
                    vm.User.FirstName = data.user.FirstName;
                    vm.User.LastName = data.user.LastName;
                    vm.User.Email = data.user.Email;
                    vm.User.UserName = data.user.UserName;
                    vm.User.PostalCode = data.user.PostalCode;
                    vm.User.PhoneNumber = data.user.PhoneNumber;
                    vm.User.Address = data.user.Address;
                    vm.User.City = data.user.City;
                    vm.User.State = data.user.State;
                });
            }
            });
        }



        function isRoleAdd(e) {
            var ids = [];
            var isval = false;
            for (var i = 0; i < vm.selectedRoles.length; i++) {
                if (vm.selectedRoles[i] == e) {
                    isval = true;
                } else {
                    ids.push(vm.selectedRoles[i]);
                }
            };

            if (!isval) {
                ids.push(e);
            }
            if (vm.selectedRoles.length == 0)
                vm.selectedRoles.push(e);
            else
                vm.selectedRoles = ids;
        }

        function setSelectedRoles(userRoles) {
        	for (var i = 0; i < vm.AllRoles.length; i++) {
        		var hasRole = $.inArray(vm.AllRoles[i].Name, userRoles.split(',')) > -1;
        		var r = new Object();
        		r.Name = vm.AllRoles[i];
        		r.enabled = hasRole;
        		vm.selectedRoles.push(r);
        	}
        }

        // Validate Form Entries
        function formValidate() {

            $.validator.addMethod('mypassword', function (value, element) {
                return this.optional(element) || (value.match(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/));
            }, 'Minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet, 1 Number and 1 Special Character.');


            var form = $('#UserAddEdit');
            form.validate({
                rules: {
                    ID: { required: true, digits: true, maxlength: 8 },
                    UserName: { required: true, maxlength: 40 },
                    Email: { required: true, maxlength: 50, email: true },
                    FirstName: { required: false,  maxlength: 50 },
                    LastName: { required: false, maxlength: 50 },
                    Address: { required: false, maxlength: 100 },
                    City: { required: false, maxlength: 50 },
                    State: { required: false, maxlength: 50 },
                    PostalCode: { required: false, digits: true, maxlength: 20 },
                    Password: { required: true, maxlength: 15, mypassword: true },
                    ConfirmPassword: {
                        required: true,
                        maxlength: 15,
                        equalTo: "#Password"
                    }
                },
                messages: {
                    ConfirmPassword: {
                        equalTo: "Password dose not match."
                    }
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

        // Save User Data
        function Save() {
            if ($('#UserAddEdit').valid()) {
                if (vm.isNew) {
                    dataContext.add("/UsersAdmin/Create", { userViewModel: vm.User, selectedRoles: vm.selectedRoles }).then(function (data) {
                        if (data.status) {
                            notify.showMessage('success', data.message);
                            window.location.hash = "#/UserAdmin";
                        } else {
                            notify.showMessage('danger', data.message);
                        }
                    });
                } else {
                    dataContext.upDate("/UsersAdmin/Edit", { editUser: vm.User, selectedRoles: vm.selectedRoles }).then(function (data) {
                        if (data.status) {
                            notify.showMessage('success', data.message);
                            window.location.hash = "#/UserAdmin";
                        } else {
                            notify.showMessage('danger', data.message);
                        }
                    });
                }
            }
        }
    }
    // End User Add/Edit Controller
})();
