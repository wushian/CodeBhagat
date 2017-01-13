(function () {
    // Start ab120 Add/Edit function
    var addEditControllerId = 'ab120AddEdit';
    angular.module('app').controller(addEditControllerId, 
		['$scope', '$location', '$routeParams', 'dataContext', '$route', 'notify', 'authService', ab120AddEdit]);

    function ab120AddEdit($scope, $location, $routeParams, dataContext, $route, notify, authService) {
        var vm = this;
        vm.Title = "Add ab120";
        vm.isNew = true;
        vm.save = Save;
		
        activate();

		// ab120 fields
        vm.ab120 = {
			gkey:"",
			ba015gkey:"",
			ba015gkey1:"",
			ac002gkey1:"",
			ac002gkey2:"",
			ac002gkey3:"",
			ac002gkey4:"",
			ab041gkey1:"",
			accountno1:"",
			ab041gkey2:"",
			accountno2:"",
			clsdd:"",
			mmend:"",
			chkdd:"",
			payee:"",
			bankinfo:"",
			swift:""
        };

		// Validate Form Entries
        function formValidate() {
            var form = $('#ab120AddEdit');
            form.validate({
                rules: {
			gkey: {required: true, maxlength: 20},
			ba015gkey: {required: true, maxlength: 20},
			ba015gkey1: {required: true, maxlength: 20},
			ac002gkey1: {required: true, maxlength: 20},
			ac002gkey2: {required: true, maxlength: 20},
			ac002gkey3: {required: true, maxlength: 20},
			ac002gkey4: {required: true, maxlength: 20},
			ab041gkey1: {required: true, maxlength: 20},
			accountno1: {required: true, maxlength: 20},
			ab041gkey2: {required: true, maxlength: 20},
			accountno2: {required: true, maxlength: 20},
			clsdd: {required: true, number: true, maxlength: 8},
			mmend: {required: true, number: true, maxlength: 8},
			chkdd: {required: true, number: true, maxlength: 8},
			payee: {required: true, maxlength: 250},
			bankinfo: {required: true, maxlength: 1073741823},
			swift: {required: true, maxlength: 80}
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

        // Save ab120 Data method
        function Save() {
            if ($('#ab120AddEdit').valid()) {
                if (vm.isNew) {
                    dataContext.add("/api/ab120",vm.ab120).then(function (data) {
                        notify.showMessage('success', "ab120 record added successfully!");
						window.location.hash = "/ab120/";
                    });
                } else {
                    dataContext.upDate("/api/ab120", vm.ab120).then(function (data) {
                        notify.showMessage('success', "ab120 record updated successfully!");
						window.location.hash = "/ab120/";
                    });
                }
            }
        }

		

    	// Bind all DropdownList with select2
        function activate() {
        	formValidate();

			
        	if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
        		vm.Title = "Edit ab120";
        		vm.isNew = false;
        		dataContext.getById("/api/ab120/" + $routeParams.gkey).then(function (data) {
        			vm.ab120 = data;
        		});
        	}
        }
    }
    // End ab120 Add/Edit function
})();
