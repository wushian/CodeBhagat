(function () {
    // User List Controller
    var ListControllerId = 'UsersAdmin';
    angular.module('app').controller(ListControllerId,
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'dataContext', 'notify', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, dataContext, notify) {
        var vmUsers = this;

        // Properties
        vmUsers.userList = [];     // the collection of all Products
        vmUsers.UserDeleteId = 0;
        vmUsers.getUsers = getUsers;        // Function binding
        vmUsers.deleteUsers = deleteUsers;
        vmUsers.confirmDelete = confirmDelete;

        activate();

        function activate() {
            getUsers();
        }

		// Get Users List
        function getUsers() {
            dataContext.get('/UsersAdmin/GetUsers').then(function (data) {
                vmUsers.userList = data.users;
            });
        }

		// Delete Users
        function deleteUsers(e) {
            vmUsers.UserDeleteId = e.Id;
            $("#modalTitle").text("User delete");
            $("#modalBody").text("Are you sure you want to delete user =" + e.UserName);
            $("#commonModal").modal('show');
        };

		// Confirm Delete
        function confirmDelete() {
            dataContext.deleteData("/UsersAdmin/DeleteConfirmed?id=" + vmUsers.UserDeleteId).then(function (data) {
                if (data.status) {
                    $("#commonModal").modal('hide');
                    vmUsers.getUsers();
                    notify.showMessage('success', data.message);
                } else {
                    notify.showMessage('success', data.message);
                }
            });
        };

    };
    // End User List Controller
})();

