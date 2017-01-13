(function () {
    // Start ab041 Details function
    var detailsControllerId = 'ab041Details';
    angular.module('app').controller(detailsControllerId, 
		['$scope', '$routeParams', 'dataContext', detail]);

    function detail($scope, $routeParams, dataContext) {

        var vmab041 = this;
		activate();
		
		vmab041.deleteab041 = deleteab041;
		vmab041.confirmDelete = confirmDelete;

        //bind all dropdownlist with select2
        function activate() {
            if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
                dataContext.getById("/api/ab041/" + $routeParams.gkey).then(function (data) {
                    vmab041.ab041 = data;
                });
            }
        };
		
		function confirmDelete() {
			dataContext.deleteData("/api/Categories?ids=" + vmab041.ab041DeleteId).then(function (data) {
				vmab041.getab041();
				vmab041.isDeleteBtn = false;

				$("#modalTitle").text("Response message");
				$("#modalBody").text("Successfully deleted.");
				window.location.hash = "/#/ab041";
			});
			//}).error(function (data, status) {
			//    $("#commonModal").modal('hide');
			//    alert("Some error occurred try again later");
			//});
		};

		function deleteab041(id) {
			//vmab041.isDeleteBtn = true;
			//vmab041.ab041DeleteId = id;
			$("#modalTitle").text("ab041 delete");
			$("#modalBody").text("Are you sure you want to delete gkey =" + id);
			$("#commonModal").modal('show');
		};
    }
    // End ab041 Details function
})();