(function () {
    // Start ab110 Details function
    var detailsControllerId = 'ab110Details';
    angular.module('app').controller(detailsControllerId, 
		['$scope', '$routeParams', 'dataContext', detail]);

    function detail($scope, $routeParams, dataContext) {

        var vmab110 = this;
		activate();
		
		vmab110.deleteab110 = deleteab110;
		vmab110.confirmDelete = confirmDelete;

        //bind all dropdownlist with select2
        function activate() {
            if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
                dataContext.getById("/api/ab110/" + $routeParams.gkey).then(function (data) {
                    vmab110.ab110 = data;
                });
            }
        };
		
		function confirmDelete() {
			dataContext.deleteData("/api/Categories?ids=" + vmab110.ab110DeleteId).then(function (data) {
				vmab110.getab110();
				vmab110.isDeleteBtn = false;

				$("#modalTitle").text("Response message");
				$("#modalBody").text("Successfully deleted.");
				window.location.hash = "/#/ab110";
			});
			//}).error(function (data, status) {
			//    $("#commonModal").modal('hide');
			//    alert("Some error occurred try again later");
			//});
		};

		function deleteab110(id) {
			//vmab110.isDeleteBtn = true;
			//vmab110.ab110DeleteId = id;
			$("#modalTitle").text("ab110 delete");
			$("#modalBody").text("Are you sure you want to delete gkey =" + id);
			$("#commonModal").modal('show');
		};
    }
    // End ab110 Details function
})();