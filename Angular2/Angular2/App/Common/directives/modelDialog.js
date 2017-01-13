app.directive('modelDialog', function () {
	var directive = {
		templateUrl: '/App/Common/directives/modelDialog.html',
		restrict: 'A',
		replace: true,
		scope: {
			title: '=',
			message: '=',
			onOK: '&',
			showOK: '='
		},
	};
	return directive;
});
