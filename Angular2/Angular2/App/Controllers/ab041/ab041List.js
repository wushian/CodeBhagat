(function () {
    // Start ab041 List function
    var ListControllerId = 'ab041List';
    angular.module('app').controller(ListControllerId, 
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'dataContext', 'authService', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, dataContext, authService) {
        if (!authService.authentication.isAuth) {
            $location.path('/login');
            return;
        }
        
        var vmab041 = this;

        //Search properties
        vmab041.ab041Search = {
			gkey:"",
			bbankno:"",
			changedd:"",
			bbankname:"",
			ebbankname:"",
			tel:"",
			fax:"",
			address:""
        };
        vmab041.isSearch = false;
        vmab041.searchQuery = "";
        // Properties
        vmab041.ab041List = [];     // the collection of all ab041
        vmab041.paging = {
            currentPage: 1,
            pageSize: 10,
            totalPages: 0,
            pagingSizeValues: [5, 10, 20, 30, 50],
			totalRecords: 0
        };  // paging related properties 

        vmab041.sortExp = "bbankno asc";

        vmab041.isDeleteBtn = false;              // hide show delete btn in dialog message
        vmab041.ab041DeleteId = 0;

        vmab041.getab041 = getab041;        // Function binding 
        vmab041.sorting = sorting;
        vmab041.selectUnselectAll = selectUnselectAll;
        vmab041.deleteab041 = deleteab041;
        vmab041.confirmDelete = confirmDelete;
        vmab041.multipleDeleteab041 = multipleDeleteab041;
        vmab041.hideShowSearchPanel = hideShowSearchPanel;
        vmab041.getSearchab041 = getSearchab041;
        vmab041.clearSearch = clearSearch;

        activate();

        function activate() {
			getab041();
			
        }

        function pageNumberDone() {
            $("#pageNoddl").select2("val", vmab041.paging.currentPage);
        }

        function getSearchab041() {
            vmab041.searchQuery = "";

            if (vmab041.ab041Search.gkey != "" && vmab041.ab041Search.gkey != undefined) {
                vmab041.searchQuery += "gkey like '%" + vmab041.ab041Search.gkey + "%' and ";
            }
            if (vmab041.ab041Search.bbankno != "" && vmab041.ab041Search.bbankno != undefined) {
                vmab041.searchQuery += "bbankno like '%" + vmab041.ab041Search.bbankno + "%' and ";
            }
            if (vmab041.ab041Search.changedd != "" && vmab041.ab041Search.changedd != undefined) {
                vmab041.searchQuery += "changedd =" + vmab041.ab041Search.changedd + " and ";
            }
            if (vmab041.ab041Search.bbankname != "" && vmab041.ab041Search.bbankname != undefined) {
                vmab041.searchQuery += "bbankname like '%" + vmab041.ab041Search.bbankname + "%' and ";
            }
            if (vmab041.ab041Search.ebbankname != "" && vmab041.ab041Search.ebbankname != undefined) {
                vmab041.searchQuery += "ebbankname like '%" + vmab041.ab041Search.ebbankname + "%' and ";
            }
            if (vmab041.ab041Search.tel != "" && vmab041.ab041Search.tel != undefined) {
                vmab041.searchQuery += "tel like '%" + vmab041.ab041Search.tel + "%' and ";
            }
            if (vmab041.ab041Search.fax != "" && vmab041.ab041Search.fax != undefined) {
                vmab041.searchQuery += "fax like '%" + vmab041.ab041Search.fax + "%' and ";
            }
            if (vmab041.ab041Search.address != "" && vmab041.ab041Search.address != undefined) {
                vmab041.searchQuery += "address like '%" + vmab041.ab041Search.address + "%' and ";
            }

            vmab041.searchQuery = vmab041.searchQuery.substring(0, vmab041.searchQuery.length - 4);
            if (vmab041.searchQuery != "" && vmab041.searchQuery != undefined) {
                vmab041.paging.currentPage = 1;
            }
            getab041();
        }

        function getab041() {
            dataContext.get('/api/ab041?filterExpression=' + vmab041.searchQuery + '&sortExpression=' + vmab041.sortExp + '&pageIndex=' + vmab041.paging.currentPage + '&pageSize=' + vmab041.paging.pageSize + '&rowsCount=0').then(function (data) {
                vmab041.ab041List = data.ab041List;
                vmab041.paging.totalPages = parseInt(data.RowsCount) == parseInt(vmab041.paging.pageSize) ? 1 : Math.floor(((parseInt(data.RowsCount) / parseInt(vmab041.paging.pageSize)) + 1));
                vmab041.paging.totalRecords = data.RowsCount;
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

                vmab041.sortExp = $($event.currentTarget).attr("data-colname") + " asc";   //update soring column in sorting exp

            } else {

                $(tds).attr("class", "sorting");  // add sorting class to every td in thead
                $(tds[0]).attr("class", "");   //remove class sorting from action coloumn 
                $(tds[1]).attr("class", "");   //remove class sorting from action coloumn 

                $($event.currentTarget).attr("class", "sorting_desc");   //add asc class in current tag
                vmab041.sortExp = $($event.currentTarget).attr("data-colname") + " desc";   //update soring column in sorting exp
            }

            getab041();
        }

        function selectUnselectAll($event) {
            var chk = $($event.currentTarget);
            if ($(chk).is(":checked")) {
                $("tbody .css-checkbox.lrg").prop("checked", true);
            } else {
                $("tbody .css-checkbox.lrg").prop("checked", false);
            }
        }

        function deleteab041(id) {
            vmab041.isDeleteBtn = true;

            vmab041.ab041DeleteId = id;
            $("#modalTitle").text("ab041 delete");
            $("#modalBody").text("Are you sure you want to delete gkey =" + id);
            $("#commonModal").modal('show');
        };

        function multipleDeleteab041() {
            vmab041.isDeleteBtn = true;
            vmab041.ab041DeleteId = "";
            $.grep($("tbody .css-checkbox.lrg:checked"), function (p, i) {
                vmab041.ab041DeleteId = vmab041.ab041DeleteId + $(p).attr("id") + ",";
            });
            $("#modalTitle").text("ab041 delete");
            $("#modalBody").text("Are you sure you want to delete ab041 =" + vmab041.productDeleteId);
            $("#commonModal").modal('show');
        }

        function confirmDelete() {
            dataContext.deleteData("/api/ab041?id=" + vmab041.ab041DeleteId).then(function (data) {
                vmab041.getab041();
                vmab041.isDeleteBtn = false;

                $("#modalTitle").text("Response message");
                $("#modalBody").text("Successfully deleted.");
                window.location.hash = "#/ab041";
            });
            //}).error(function (data, status) {
            //    $("#commonModal").modal('hide');
            //    alert("Some error occurred try again later");
            //});
        };

        function hideShowSearchPanel() {
            vmab041.isSearch = !vmab041.isSearch;
        };



        function clearSearch() {
			vmab041.ab041Search = {
			gkey:"",
			bbankno:"",
			changedd:"",
			bbankname:"",
			ebbankname:"",
			tel:"",
			fax:"",
			address:""
	        };
            vmab041.searchQuery = "";
            getab041();
        }
    };
    // End ab041 List function
})();

