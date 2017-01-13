(function () {
    // Start ab041 Add/Edit function
    var addEditControllerId = 'ab041AddEdit';
    angular.module('app').controller(addEditControllerId, 
		['$scope', '$location', '$routeParams', 'dataContext', '$route', 'notify', 'authService', ab041AddEdit]);

    function ab041AddEdit($scope, $location, $routeParams, dataContext, $route, notify, authService) {
        var vm = this;
        vm.Title = "Add ab041";
        vm.isNew = true;
        vm.save = Save;
		
        activate();

		// ab041 fields
        vm.ab041 = {
			gkey:"",
			bbankno:"",
			changedd:"",
			bbankname:"",
			ebbankname:"",
			tel:"",
			fax:"",
			address:""
        };

		// Validate Form Entries
        function formValidate() {
            var form = $('#ab041AddEdit');
            form.validate({
                rules: {
			gkey: {required: true, maxlength: 20},
			bbankno: {required: true, maxlength: 20},
			changedd: {required: true, number: true, maxlength: 8},
			bbankname: {required: true, maxlength: 80},
			ebbankname: {required: true, maxlength: 60},
			tel: {required: true, maxlength: 40},
			fax: {required: true, maxlength: 40},
			address: {required: true, maxlength: 100}
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

        // Save ab041 Data method
        function Save() {
            if ($('#ab041AddEdit').valid()) {
                if (vm.isNew) {
                    dataContext.add("/api/ab041",vm.ab041).then(function (data) {
                        notify.showMessage('success', "ab041 record added successfully!");
						window.location.hash = "/ab041/";
                    });
                } else {
                    dataContext.upDate("/api/ab041", vm.ab041).then(function (data) {
                        notify.showMessage('success', "ab041 record updated successfully!");
						window.location.hash = "/ab041/";
                    });
                }
            }
        }

		

    	// Bind all DropdownList with select2
        function activate() {
        	formValidate();

			
        	if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
        		vm.Title = "Edit ab041";
        		vm.isNew = false;
        		dataContext.getById("/api/ab041/" + $routeParams.gkey).then(function (data) {
        			vm.ab041 = data;
        		});
        	}
        }
    }
    // End ab041 Add/Edit function
})();
