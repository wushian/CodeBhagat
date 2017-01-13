(function () {
    // User Details Controller
    var detailsControllerId = 'UserDetails';
    angular.module('app').controller(detailsControllerId,
		['$scope', '$routeParams', 'dataContext', detail]);

    function detail($scope, $routeParams, dataContext) {
        var vm = this;

        // User object
        vm.user = {
            FirstName: "",
            LastName: "",
            Address: "",
            City: "",
            State: "",
            PostalCode: "",
            Roles: "",
            Email: "",
            PhoneNumber: ""
        };

        activate();

        //bind all dropdownlist with select2
        function activate() {
            if ($routeParams.UserId != undefined && $routeParams.UserId != "" && $routeParams.UserId != null) {
                dataContext.getById("/UsersAdmin/Details/" + $routeParams.UserId).then(function (data) {
                    vm.user = data.user;
                });
            }
        };
    }
    // End User Details Controller
})();