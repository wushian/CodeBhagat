(function () {
    // Start Role List function
    var ListControllerId = 'RolesList';
    angular.module('app').controller(ListControllerId,
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'notify', 'dataContext', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, notify, dataContext) {
        var vmRoles = this;

        vmRoles.isDeleteBtn = false;              // hide show delete btn in dialog message
        vmRoles.RoleDeleteId = 0;
        vmRoles.getRole = getRole;        // Function binding
        vmRoles.deleteRole = deleteRole;
        vmRoles.confirmDelete = confirmDelete;

        vmRoles.add = add;
        vmRoles.edit = edit;
        vmRoles.save = save;
        vmRoles.isadd = true;
        vmRoles.Title = "Add Role";
        vmRoles.isDelete = false;
        vmRoles.deleteMessage = "";

        activate();

        // Roles object
        vmRoles.Roles = {
            Id: "",
            Name: "",
            Description: ""
        };

        function activate() {
            getRole();
        }

		// Get Roles List
        function getRole() {
            dataContext.get('/RolesAdmin/GetRoles').then(function (data) {
                vmRoles.RoleList = data.roles;
            });
        }

        // Validate Form Entries
        function formValidate() {
            var form = $('#RolesAddEdit');
            form.validate({
                rules: {
                    Name: { required: true, maxlength: 50 },
                    Description: { required: true, maxlength: 100 },
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

		// Unselect All Roles
        function selectUnselectAll($event) {
            var chk = $($event.currentTarget);
            if ($(chk).is(":checked")) {
                $("tbody .css-checkbox.lrg").prop("checked", true);
            } else {
                $("tbody .css-checkbox.lrg").prop("checked", false);
            }
        }

		// Add Role
        function add() {
            vmRoles.isDelete = false;
            vmRoles.Title = "Add Role";
            vmRoles.isadd = true;
            vmRoles.Roles.Id = null;
            vmRoles.Roles.Name = null;
            vmRoles.Roles.Description = null;

            $("#commonModal").modal('show');
            formValidate();
        }

		// Save Role data
        function save() {
            if ($('#RolesAddEdit').valid()) {
                if (vmRoles.isadd) {
                    dataContext.add("/RolesAdmin/Create", vmRoles.Roles).then(function (data) {
                        if (data.status) {
                            getRole();
                            notify.showMessage('success', "Role record added successfully!");
                        } else {
                            notify.showMessage('danger', data.message);
                        }
                    });
                } else {
                    dataContext.upDate("/RolesAdmin/Edit", vmRoles.Roles).then(function (data) {
                        notify.showMessage('success', "Role record updated successfully!");
                        getRole();
                    });
                }
                $("#commonModal").modal('hide');
                vmRoles.getRole();
            }
        }

		// Edit Role
        function edit(e) {
            vmRoles.isDelete = false;
            vmRoles.isadd = false;
            vmRoles.Title = "Edit Role";

            vmRoles.Roles.Id = e.Id;
            vmRoles.Roles.Name = e.Name;
            vmRoles.Roles.Description = e.Description;

            $("#commonModal").modal('show');
        }

		// Delete Role
        function deleteRole(b) {
            vmRoles.isDelete = true;

            vmRoles.Title = "Delete Role";
            vmRoles.deleteMessage = "Are you sure to want delete '" + b.Name + "' role.";
            vmRoles.Roles.Id = b.Id;
            $("#commonModal").modal('show');
        };

		// Confirm Role Deletion
        function confirmDelete() {
            dataContext.deleteData("/RolesAdmin/DeleteConfirmed?id=" + vmRoles.Roles.Id).then(function (data) {
                vmRoles.getRole();
                $("#commonModal").modal('hide');
                if (data.status) {
                    notify.showMessage('success', data.message);
                } else {
                    notify.showMessage('danger', data.message);
                }
            });
        };
    };
    // End Role List function
})();

