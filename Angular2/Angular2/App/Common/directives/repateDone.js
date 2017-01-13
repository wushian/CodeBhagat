app.directive('repeatDone', function () {
    return function (scope, element, attrs) {
        if (scope.$last) {
            scope.$evalAsync(attrs.repeatDone);
        }
    }
}); 