(function () {
    // Start ab121sg Add/Edit function
    var addEditControllerId = 'ab121sgAddEdit';
    angular.module('app').controller(addEditControllerId, 
		['$scope', '$location', '$routeParams', 'dataContext', '$route', 'notify', 'authService', ab121sgAddEdit]);

    function ab121sgAddEdit($scope, $location, $routeParams, dataContext, $route, notify, authService) {
        var vm = this;
        vm.Title = "Add ab121sg";
        vm.isNew = true;
        vm.save = Save;
		
        activate();

		// ab121sg fields
        vm.ab121sg = {
			gkey:"",
			ba015gkey:"",
			ba005gkey:""
        };

		// Validate Form Entries
        function formValidate() {
            var form = $('#ab121sgAddEdit');
            form.validate({
                rules: {
			gkey: {required: true, maxlength: 20},
			ba015gkey: {required: true, maxlength: 20},
			ba005gkey: {required: true, maxlength: 20}
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

        // Save ab121sg Data method
        function Save() {
            if ($('#ab121sgAddEdit').valid()) {
                if (vm.isNew) {
                    dataContext.add("/api/ab121sg",vm.ab121sg).then(function (data) {
                        notify.showMessage('success', "ab121sg record added successfully!");
						window.location.hash = "/ab121sg/";
                    });
                } else {
                    dataContext.upDate("/api/ab121sg", vm.ab121sg).then(function (data) {
                        notify.showMessage('success', "ab121sg record updated successfully!");
						window.location.hash = "/ab121sg/";
                    });
                }
            }
        }

		

    	// Bind all DropdownList with select2
        function activate() {
        	formValidate();

			
        	if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
        		vm.Title = "Edit ab121sg";
        		vm.isNew = false;
        		dataContext.getById("/api/ab121sg/" + $routeParams.gkey).then(function (data) {
        			vm.ab121sg = data;
        		});
        	}
        }
    }
    // End ab121sg Add/Edit function
})();
