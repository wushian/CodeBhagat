(function () {
    // Start ab121sg Details function
    var detailsControllerId = 'ab121sgDetails';
    angular.module('app').controller(detailsControllerId, 
		['$scope', '$routeParams', 'dataContext', detail]);

    function detail($scope, $routeParams, dataContext) {

        var vmab121sg = this;
		activate();
		
		vmab121sg.deleteab121sg = deleteab121sg;
		vmab121sg.confirmDelete = confirmDelete;

        //bind all dropdownlist with select2
        function activate() {
            if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
                dataContext.getById("/api/ab121sg/" + $routeParams.gkey).then(function (data) {
                    vmab121sg.ab121sg = data;
                });
            }
        };
		
		function confirmDelete() {
			dataContext.deleteData("/api/Categories?ids=" + vmab121sg.ab121sgDeleteId).then(function (data) {
				vmab121sg.getab121sg();
				vmab121sg.isDeleteBtn = false;

				$("#modalTitle").text("Response message");
				$("#modalBody").text("Successfully deleted.");
				window.location.hash = "/#/ab121sg";
			});
			//}).error(function (data, status) {
			//    $("#commonModal").modal('hide');
			//    alert("Some error occurred try again later");
			//});
		};

		function deleteab121sg(id) {
			//vmab121sg.isDeleteBtn = true;
			//vmab121sg.ab121sgDeleteId = id;
			$("#modalTitle").text("ab121sg delete");
			$("#modalBody").text("Are you sure you want to delete gkey =" + id);
			$("#commonModal").modal('show');
		};
    }
    // End ab121sg Details function
})();