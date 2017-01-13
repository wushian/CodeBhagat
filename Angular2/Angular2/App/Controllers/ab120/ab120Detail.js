(function () {
    // Start ab120 Details function
    var detailsControllerId = 'ab120Details';
    angular.module('app').controller(detailsControllerId, 
		['$scope', '$routeParams', 'dataContext', detail]);

    function detail($scope, $routeParams, dataContext) {

        var vmab120 = this;
		activate();
		
		vmab120.deleteab120 = deleteab120;
		vmab120.confirmDelete = confirmDelete;

        //bind all dropdownlist with select2
        function activate() {
            if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
                dataContext.getById("/api/ab120/" + $routeParams.gkey).then(function (data) {
                    vmab120.ab120 = data;
                });
            }
        };
		
		function confirmDelete() {
			dataContext.deleteData("/api/Categories?ids=" + vmab120.ab120DeleteId).then(function (data) {
				vmab120.getab120();
				vmab120.isDeleteBtn = false;

				$("#modalTitle").text("Response message");
				$("#modalBody").text("Successfully deleted.");
				window.location.hash = "/#/ab120";
			});
			//}).error(function (data, status) {
			//    $("#commonModal").modal('hide');
			//    alert("Some error occurred try again later");
			//});
		};

		function deleteab120(id) {
			//vmab120.isDeleteBtn = true;
			//vmab120.ab120DeleteId = id;
			$("#modalTitle").text("ab120 delete");
			$("#modalBody").text("Are you sure you want to delete gkey =" + id);
			$("#commonModal").modal('show');
		};
    }
    // End ab120 Details function
})();