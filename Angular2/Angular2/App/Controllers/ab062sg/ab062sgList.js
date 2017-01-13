(function () {
    // Start ab062sg List function
    var ListControllerId = 'ab062sgList';
    angular.module('app').controller(ListControllerId, 
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'dataContext', 'authService', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, dataContext, authService) {
        if (!authService.authentication.isAuth) {
            $location.path('/login');
            return;
        }
        
        var vmab062sg = this;

        //Search properties
        vmab062sg.ab062sgSearch = {
			gkey:"",
			ba060gkey:"",
			rate:"",
			ym:""
        };
        vmab062sg.isSearch = false;
        vmab062sg.searchQuery = "";
        // Properties
        vmab062sg.ab062sgList = [];     // the collection of all ab062sg
        vmab062sg.paging = {
            currentPage: 1,
            pageSize: 10,
            totalPages: 0,
            pagingSizeValues: [5, 10, 20, 30, 50],
			totalRecords: 0
        };  // paging related properties 

        vmab062sg.sortExp = "ba060gkey asc";

        vmab062sg.isDeleteBtn = false;              // hide show delete btn in dialog message
        vmab062sg.ab062sgDeleteId = 0;

        vmab062sg.getab062sg = getab062sg;        // Function binding 
        vmab062sg.sorting = sorting;
        vmab062sg.selectUnselectAll = selectUnselectAll;
        vmab062sg.deleteab062sg = deleteab062sg;
        vmab062sg.confirmDelete = confirmDelete;
        vmab062sg.multipleDeleteab062sg = multipleDeleteab062sg;
        vmab062sg.hideShowSearchPanel = hideShowSearchPanel;
        vmab062sg.getSearchab062sg = getSearchab062sg;
        vmab062sg.clearSearch = clearSearch;

        activate();

        function activate() {
			getab062sg();
			
        }

        function pageNumberDone() {
            $("#pageNoddl").select2("val", vmab062sg.paging.currentPage);
        }

        function getSearchab062sg() {
            vmab062sg.searchQuery = "";

            if (vmab062sg.ab062sgSearch.gkey != "" && vmab062sg.ab062sgSearch.gkey != undefined) {
                vmab062sg.searchQuery += "gkey like '%" + vmab062sg.ab062sgSearch.gkey + "%' and ";
            }
            if (vmab062sg.ab062sgSearch.ba060gkey != "" && vmab062sg.ab062sgSearch.ba060gkey != undefined) {
                vmab062sg.searchQuery += "ba060gkey like '%" + vmab062sg.ab062sgSearch.ba060gkey + "%' and ";
            }
            if (vmab062sg.ab062sgSearch.rate != "" && vmab062sg.ab062sgSearch.rate != undefined) {
                vmab062sg.searchQuery += "rate =" + vmab062sg.ab062sgSearch.rate + " and ";
            }
            if (vmab062sg.ab062sgSearch.ym != "" && vmab062sg.ab062sgSearch.ym != undefined) {
                vmab062sg.searchQuery += "ym like '%" + vmab062sg.ab062sgSearch.ym + "%' and ";
            }

            vmab062sg.searchQuery = vmab062sg.searchQuery.substring(0, vmab062sg.searchQuery.length - 4);
            if (vmab062sg.searchQuery != "" && vmab062sg.searchQuery != undefined) {
                vmab062sg.paging.currentPage = 1;
            }
            getab062sg();
        }

        function getab062sg() {
            dataContext.get('/api/ab062sg?filterExpression=' + vmab062sg.searchQuery + '&sortExpression=' + vmab062sg.sortExp + '&pageIndex=' + vmab062sg.paging.currentPage + '&pageSize=' + vmab062sg.paging.pageSize + '&rowsCount=0').then(function (data) {
                vmab062sg.ab062sgList = data.ab062sgList;
                vmab062sg.paging.totalPages = parseInt(data.RowsCount) == parseInt(vmab062sg.paging.pageSize) ? 1 : Math.floor(((parseInt(data.RowsCount) / parseInt(vmab062sg.paging.pageSize)) + 1));
                vmab062sg.paging.totalRecords = data.RowsCount;
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

                vmab062sg.sortExp = $($event.currentTarget).attr("data-colname") + " asc";   //update soring column in sorting exp

            } else {

                $(tds).attr("class", "sorting");  // add sorting class to every td in thead
                $(tds[0]).attr("class", "");   //remove class sorting from action coloumn 
                $(tds[1]).attr("class", "");   //remove class sorting from action coloumn 

                $($event.currentTarget).attr("class", "sorting_desc");   //add asc class in current tag
                vmab062sg.sortExp = $($event.currentTarget).attr("data-colname") + " desc";   //update soring column in sorting exp
            }

            getab062sg();
        }

        function selectUnselectAll($event) {
            var chk = $($event.currentTarget);
            if ($(chk).is(":checked")) {
                $("tbody .css-checkbox.lrg").prop("checked", true);
            } else {
                $("tbody .css-checkbox.lrg").prop("checked", false);
            }
        }

        function deleteab062sg(id) {
            vmab062sg.isDeleteBtn = true;

            vmab062sg.ab062sgDeleteId = id;
            $("#modalTitle").text("ab062sg delete");
            $("#modalBody").text("Are you sure you want to delete gkey =" + id);
            $("#commonModal").modal('show');
        };

        function multipleDeleteab062sg() {
            vmab062sg.isDeleteBtn = true;
            vmab062sg.ab062sgDeleteId = "";
            $.grep($("tbody .css-checkbox.lrg:checked"), function (p, i) {
                vmab062sg.ab062sgDeleteId = vmab062sg.ab062sgDeleteId + $(p).attr("id") + ",";
            });
            $("#modalTitle").text("ab062sg delete");
            $("#modalBody").text("Are you sure you want to delete ab062sg =" + vmab062sg.productDeleteId);
            $("#commonModal").modal('show');
        }

        function confirmDelete() {
            dataContext.deleteData("/api/ab062sg?id=" + vmab062sg.ab062sgDeleteId).then(function (data) {
                vmab062sg.getab062sg();
                vmab062sg.isDeleteBtn = false;

                $("#modalTitle").text("Response message");
                $("#modalBody").text("Successfully deleted.");
                window.location.hash = "#/ab062sg";
            });
            //}).error(function (data, status) {
            //    $("#commonModal").modal('hide');
            //    alert("Some error occurred try again later");
            //});
        };

        function hideShowSearchPanel() {
            vmab062sg.isSearch = !vmab062sg.isSearch;
        };



        function clearSearch() {
			vmab062sg.ab062sgSearch = {
			gkey:"",
			ba060gkey:"",
			rate:"",
			ym:""
	        };
            vmab062sg.searchQuery = "";
            getab062sg();
        }
    };
    // End ab062sg List function
})();

