(function () {
    // Start ab110 Add/Edit function
    var addEditControllerId = 'ab110AddEdit';
    angular.module('app').controller(addEditControllerId, 
		['$scope', '$location', '$routeParams', 'dataContext', '$route', 'notify', 'authService', ab110AddEdit]);

    function ab110AddEdit($scope, $location, $routeParams, dataContext, $route, notify, authService) {
        var vm = this;
        vm.Title = "Add ab110";
        vm.isNew = true;
        vm.save = Save;
		
        activate();

		// ab110 fields
        vm.ab110 = {
			gkey:"",
			ba010gkey:"",
			ba010gkey1:"",
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
            var form = $('#ab110AddEdit');
            form.validate({
                rules: {
			gkey: {required: true, maxlength: 20},
			ba010gkey: {required: true, maxlength: 20},
			ba010gkey1: {required: true, maxlength: 20},
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

        // Save ab110 Data method
        function Save() {
            if ($('#ab110AddEdit').valid()) {
                if (vm.isNew) {
                    dataContext.add("/api/ab110",vm.ab110).then(function (data) {
                        notify.showMessage('success', "ab110 record added successfully!");
						window.location.hash = "/ab110/";
                    });
                } else {
                    dataContext.upDate("/api/ab110", vm.ab110).then(function (data) {
                        notify.showMessage('success', "ab110 record updated successfully!");
						window.location.hash = "/ab110/";
                    });
                }
            }
        }

		

    	// Bind all DropdownList with select2
        function activate() {
        	formValidate();

			
        	if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
        		vm.Title = "Edit ab110";
        		vm.isNew = false;
        		dataContext.getById("/api/ab110/" + $routeParams.gkey).then(function (data) {
        			vm.ab110 = data;
        		});
        	}
        }
    }
    // End ab110 Add/Edit function
})();
