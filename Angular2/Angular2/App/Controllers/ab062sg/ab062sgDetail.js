(function () {
    // Start ab062sg Details function
    var detailsControllerId = 'ab062sgDetails';
    angular.module('app').controller(detailsControllerId, 
		['$scope', '$routeParams', 'dataContext', detail]);

    function detail($scope, $routeParams, dataContext) {

        var vmab062sg = this;
		activate();
		
		vmab062sg.deleteab062sg = deleteab062sg;
		vmab062sg.confirmDelete = confirmDelete;

        //bind all dropdownlist with select2
        function activate() {
            if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
                dataContext.getById("/api/ab062sg/" + $routeParams.gkey).then(function (data) {
                    vmab062sg.ab062sg = data;
                });
            }
        };
		
		function confirmDelete() {
			dataContext.deleteData("/api/Categories?ids=" + vmab062sg.ab062sgDeleteId).then(function (data) {
				vmab062sg.getab062sg();
				vmab062sg.isDeleteBtn = false;

				$("#modalTitle").text("Response message");
				$("#modalBody").text("Successfully deleted.");
				window.location.hash = "/#/ab062sg";
			});
			//}).error(function (data, status) {
			//    $("#commonModal").modal('hide');
			//    alert("Some error occurred try again later");
			//});
		};

		function deleteab062sg(id) {
			//vmab062sg.isDeleteBtn = true;
			//vmab062sg.ab062sgDeleteId = id;
			$("#modalTitle").text("ab062sg delete");
			$("#modalBody").text("Are you sure you want to delete gkey =" + id);
			$("#commonModal").modal('show');
		};
    }
    // End ab062sg Details function
})();