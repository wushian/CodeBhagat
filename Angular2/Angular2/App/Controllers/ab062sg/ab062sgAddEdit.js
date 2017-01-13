(function () {
    // Start ab062sg Add/Edit function
    var addEditControllerId = 'ab062sgAddEdit';
    angular.module('app').controller(addEditControllerId, 
		['$scope', '$location', '$routeParams', 'dataContext', '$route', 'notify', 'authService', ab062sgAddEdit]);

    function ab062sgAddEdit($scope, $location, $routeParams, dataContext, $route, notify, authService) {
        var vm = this;
        vm.Title = "Add ab062sg";
        vm.isNew = true;
        vm.save = Save;
		
        activate();

		// ab062sg fields
        vm.ab062sg = {
			gkey:"",
			ba060gkey:"",
			rate:"",
			ym:""
        };

		// Validate Form Entries
        function formValidate() {
            var form = $('#ab062sgAddEdit');
            form.validate({
                rules: {
			gkey: {required: true, maxlength: 20},
			ba060gkey: {required: true, maxlength: 20},
			rate: {required: true, number: true, maxlength: 8},
			ym: {required: true, maxlength: 6}
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

        // Save ab062sg Data method
        function Save() {
            if ($('#ab062sgAddEdit').valid()) {
                if (vm.isNew) {
                    dataContext.add("/api/ab062sg",vm.ab062sg).then(function (data) {
                        notify.showMessage('success', "ab062sg record added successfully!");
						window.location.hash = "/ab062sg/";
                    });
                } else {
                    dataContext.upDate("/api/ab062sg", vm.ab062sg).then(function (data) {
                        notify.showMessage('success', "ab062sg record updated successfully!");
						window.location.hash = "/ab062sg/";
                    });
                }
            }
        }

		

    	// Bind all DropdownList with select2
        function activate() {
        	formValidate();

			
        	if ($routeParams.gkey != undefined && $routeParams.gkey != "" && $routeParams.gkey != null) {
        		vm.Title = "Edit ab062sg";
        		vm.isNew = false;
        		dataContext.getById("/api/ab062sg/" + $routeParams.gkey).then(function (data) {
        			vm.ab062sg = data;
        		});
        	}
        }
    }
    // End ab062sg Add/Edit function
})();
