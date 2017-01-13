(function () {
    // Start ab121sg List function
    var ListControllerId = 'ab121sgList';
    angular.module('app').controller(ListControllerId, 
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'dataContext', 'authService', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, dataContext, authService) {
        if (!authService.authentication.isAuth) {
            $location.path('/login');
            return;
        }
        
        var vmab121sg = this;

        //Search properties
        vmab121sg.ab121sgSearch = {
			gkey:"",
			ba015gkey:"",
			ba005gkey:""
        };
        vmab121sg.isSearch = false;
        vmab121sg.searchQuery = "";
        // Properties
        vmab121sg.ab121sgList = [];     // the collection of all ab121sg
        vmab121sg.paging = {
            currentPage: 1,
            pageSize: 10,
            totalPages: 0,
            pagingSizeValues: [5, 10, 20, 30, 50],
			totalRecords: 0
        };  // paging related properties 

        vmab121sg.sortExp = "ba015gkey asc";

        vmab121sg.isDeleteBtn = false;              // hide show delete btn in dialog message
        vmab121sg.ab121sgDeleteId = 0;

        vmab121sg.getab121sg = getab121sg;        // Function binding 
        vmab121sg.sorting = sorting;
        vmab121sg.selectUnselectAll = selectUnselectAll;
        vmab121sg.deleteab121sg = deleteab121sg;
        vmab121sg.confirmDelete = confirmDelete;
        vmab121sg.multipleDeleteab121sg = multipleDeleteab121sg;
        vmab121sg.hideShowSearchPanel = hideShowSearchPanel;
        vmab121sg.getSearchab121sg = getSearchab121sg;
        vmab121sg.clearSearch = clearSearch;

        activate();

        function activate() {
			getab121sg();
			
        }

        function pageNumberDone() {
            $("#pageNoddl").select2("val", vmab121sg.paging.currentPage);
        }

        function getSearchab121sg() {
            vmab121sg.searchQuery = "";

            if (vmab121sg.ab121sgSearch.gkey != "" && vmab121sg.ab121sgSearch.gkey != undefined) {
                vmab121sg.searchQuery += "gkey like '%" + vmab121sg.ab121sgSearch.gkey + "%' and ";
            }
            if (vmab121sg.ab121sgSearch.ba015gkey != "" && vmab121sg.ab121sgSearch.ba015gkey != undefined) {
                vmab121sg.searchQuery += "ba015gkey like '%" + vmab121sg.ab121sgSearch.ba015gkey + "%' and ";
            }
            if (vmab121sg.ab121sgSearch.ba005gkey != "" && vmab121sg.ab121sgSearch.ba005gkey != undefined) {
                vmab121sg.searchQuery += "ba005gkey like '%" + vmab121sg.ab121sgSearch.ba005gkey + "%' and ";
            }

            vmab121sg.searchQuery = vmab121sg.searchQuery.substring(0, vmab121sg.searchQuery.length - 4);
            if (vmab121sg.searchQuery != "" && vmab121sg.searchQuery != undefined) {
                vmab121sg.paging.currentPage = 1;
            }
            getab121sg();
        }

        function getab121sg() {
            dataContext.get('/api/ab121sg?filterExpression=' + vmab121sg.searchQuery + '&sortExpression=' + vmab121sg.sortExp + '&pageIndex=' + vmab121sg.paging.currentPage + '&pageSize=' + vmab121sg.paging.pageSize + '&rowsCount=0').then(function (data) {
                vmab121sg.ab121sgList = data.ab121sgList;
                vmab121sg.paging.totalPages = parseInt(data.RowsCount) == parseInt(vmab121sg.paging.pageSize) ? 1 : Math.floor(((parseInt(data.RowsCount) / parseInt(vmab121sg.paging.pageSize)) + 1));
                vmab121sg.paging.totalRecords = data.RowsCount;
            });
        }

        //asc desc sorting function
        function sorting($event) {
            //get all thead td 
            var tds = $($($event.currentTarget).parents('thead')).find('td');

            //check sorting or desc 
            if ($($event.currentTarget).hasClass("sorting") == true || $($event.currentTarget).hasClass("sorting_desc") == true) {

                $(tds).attr("class", "sorting");  // add sorting class to every td in thead
                $(tds[0]).attr("class", "");   //remove class sorting from action coloumn 
                $(tds[1]).attr("class", "");   //remove class sorting from action coloumn 

                $($event.currentTarget).attr("class", "sorting_asc");   //add asc class in current tag

                vmab121sg.sortExp = $($event.currentTarget).attr("data-colname") + " asc";   //update soring column in sorting exp

            } else {

                $(tds).attr("class", "sorting");  // add sorting class to every td in thead
                $(tds[0]).attr("class", "");   //remove class sorting from action coloumn 
                $(tds[1]).attr("class", "");   //remove class sorting from action coloumn 

                $($event.currentTarget).attr("class", "sorting_desc");   //add asc class in current tag
                vmab121sg.sortExp = $($event.currentTarget).attr("data-colname") + " desc";   //update soring column in sorting exp
            }

            getab121sg();
        }

        function selectUnselectAll($event) {
            var chk = $($event.currentTarget);
            if ($(chk).is(":checked")) {
                $("tbody .css-checkbox.lrg").prop("checked", true);
            } else {
                $("tbody .css-checkbox.lrg").prop("checked", false);
            }
        }

        function deleteab121sg(id) {
            vmab121sg.isDeleteBtn = true;

            vmab121sg.ab121sgDeleteId = id;
            $("#modalTitle").text("ab121sg delete");
            $("#modalBody").text("Are you sure you want to delete gkey =" + id);
            $("#commonModal").modal('show');
        };

        function multipleDeleteab121sg() {
            vmab121sg.isDeleteBtn = true;
            vmab121sg.ab121sgDeleteId = "";
            $.grep($("tbody .css-checkbox.lrg:checked"), function (p, i) {
                vmab121sg.ab121sgDeleteId = vmab121sg.ab121sgDeleteId + $(p).attr("id") + ",";
            });
            $("#modalTitle").text("ab121sg delete");
            $("#modalBody").text("Are you sure you want to delete ab121sg =" + vmab121sg.productDeleteId);
            $("#commonModal").modal('show');
        }

        function confirmDelete() {
            dataContext.deleteData("/api/ab121sg?id=" + vmab121sg.ab121sgDeleteId).then(function (data) {
                vmab121sg.getab121sg();
                vmab121sg.isDeleteBtn = false;

                $("#modalTitle").text("Response message");
                $("#modalBody").text("Successfully deleted.");
                window.location.hash = "#/ab121sg";
            });
            //}).error(function (data, status) {
            //    $("#commonModal").modal('hide');
            //    alert("Some error occurred try again later");
            //});
        };

        function hideShowSearchPanel() {
            vmab121sg.isSearch = !vmab121sg.isSearch;
        };



        function clearSearch() {
			vmab121sg.ab121sgSearch = {
			gkey:"",
			ba015gkey:"",
			ba005gkey:""
	        };
            vmab121sg.searchQuery = "";
            getab121sg();
        }
    };
    // End ab121sg List function
})();

