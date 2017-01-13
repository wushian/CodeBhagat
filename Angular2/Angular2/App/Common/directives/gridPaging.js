app.directive('gridPaging', function () {
    var directive = {
        templateUrl: '/App/Common/directives/gridPaging.html',
        restrict: 'A',
        replace: true,
        scope: {
            getData: '&',
            paging: '='
        },
        controller: function ($scope) {

            $scope.$watch('paging.currentPage', function (newVal, prevVal) {
                if (newVal != prevVal) {
                    $scope.paging.currentPage = parseInt(newVal);
                    $scope.$eval($scope.getData);
                    $("#pageNoddl").select2("val",parseInt(newVal))
                }
            });
            $scope.$watch('paging.pageSize', function (newVal, prevVal) {
                if (newVal != prevVal) {
                    $scope.$eval($scope.getData);
                }
            });
            setTimeout(function () {
                $("#pagesizeddl").select2();
                $("#pageNoddl").select2({ width: '60px', val: $scope.paging.currentPage });
            }, 500);
        }
    };
    return directive;
});
