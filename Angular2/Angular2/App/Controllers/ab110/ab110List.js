(function () {
    // Start ab110 List function
    var ListControllerId = 'ab110List';
    angular.module('app').controller(ListControllerId, 
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'dataContext', 'authService', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, dataContext, authService) {
        if (!authService.authentication.isAuth) {
            $location.path('/login');
            return;
        }
        
        var vmab110 = this;

        //Search properties
        vmab110.ab110Search = {
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
        vmab110.isSearch = false;
        vmab110.searchQuery = "";
        // Properties
        vmab110.ab110List = [];     // the collection of all ab110
        vmab110.paging = {
            currentPage: 1,
            pageSize: 10,
            totalPages: 0,
            pagingSizeValues: [5, 10, 20, 30, 50],
			totalRecords: 0
        };  // paging related properties 

        vmab110.sortExp = "ba010gkey asc";

        vmab110.isDeleteBtn = false;              // hide show delete btn in dialog message
        vmab110.ab110DeleteId = 0;

        vmab110.getab110 = getab110;        // Function binding 
        vmab110.sorting = sorting;
        vmab110.selectUnselectAll = selectUnselectAll;
        vmab110.deleteab110 = deleteab110;
        vmab110.confirmDelete = confirmDelete;
        vmab110.multipleDeleteab110 = multipleDeleteab110;
        vmab110.hideShowSearchPanel = hideShowSearchPanel;
        vmab110.getSearchab110 = getSearchab110;
        vmab110.clearSearch = clearSearch;

        activate();

        function activate() {
			getab110();
			
        }

        function pageNumberDone() {
            $("#pageNoddl").select2("val", vmab110.paging.currentPage);
        }

        function getSearchab110() {
            vmab110.searchQuery = "";

            if (vmab110.ab110Search.gkey != "" && vmab110.ab110Search.gkey != undefined) {
                vmab110.searchQuery += "gkey like '%" + vmab110.ab110Search.gkey + "%' and ";
            }
            if (vmab110.ab110Search.ba010gkey != "" && vmab110.ab110Search.ba010gkey != undefined) {
                vmab110.searchQuery += "ba010gkey like '%" + vmab110.ab110Search.ba010gkey + "%' and ";
            }
            if (vmab110.ab110Search.ba010gkey1 != "" && vmab110.ab110Search.ba010gkey1 != undefined) {
                vmab110.searchQuery += "ba010gkey1 like '%" + vmab110.ab110Search.ba010gkey1 + "%' and ";
            }
            if (vmab110.ab110Search.ac002gkey1 != "" && vmab110.ab110Search.ac002gkey1 != undefined) {
                vmab110.searchQuery += "ac002gkey1 like '%" + vmab110.ab110Search.ac002gkey1 + "%' and ";
            }
            if (vmab110.ab110Search.ac002gkey2 != "" && vmab110.ab110Search.ac002gkey2 != undefined) {
                vmab110.searchQuery += "ac002gkey2 like '%" + vmab110.ab110Search.ac002gkey2 + "%' and ";
            }
            if (vmab110.ab110Search.ac002gkey3 != "" && vmab110.ab110Search.ac002gkey3 != undefined) {
                vmab110.searchQuery += "ac002gkey3 like '%" + vmab110.ab110Search.ac002gkey3 + "%' and ";
            }
            if (vmab110.ab110Search.ac002gkey4 != "" && vmab110.ab110Search.ac002gkey4 != undefined) {
                vmab110.searchQuery += "ac002gkey4 like '%" + vmab110.ab110Search.ac002gkey4 + "%' and ";
            }
            if (vmab110.ab110Search.ab041gkey1 != "" && vmab110.ab110Search.ab041gkey1 != undefined) {
                vmab110.searchQuery += "ab041gkey1 like '%" + vmab110.ab110Search.ab041gkey1 + "%' and ";
            }
            if (vmab110.ab110Search.accountno1 != "" && vmab110.ab110Search.accountno1 != undefined) {
                vmab110.searchQuery += "accountno1 like '%" + vmab110.ab110Search.accountno1 + "%' and ";
            }
            if (vmab110.ab110Search.ab041gkey2 != "" && vmab110.ab110Search.ab041gkey2 != undefined) {
                vmab110.searchQuery += "ab041gkey2 like '%" + vmab110.ab110Search.ab041gkey2 + "%' and ";
            }
            if (vmab110.ab110Search.accountno2 != "" && vmab110.ab110Search.accountno2 != undefined) {
                vmab110.searchQuery += "accountno2 like '%" + vmab110.ab110Search.accountno2 + "%' and ";
            }
            if (vmab110.ab110Search.clsdd != "" && vmab110.ab110Search.clsdd != undefined) {
                vmab110.searchQuery += "clsdd =" + vmab110.ab110Search.clsdd + " and ";
            }
            if (vmab110.ab110Search.mmend != "" && vmab110.ab110Search.mmend != undefined) {
                vmab110.searchQuery += "mmend =" + vmab110.ab110Search.mmend + " and ";
            }
            if (vmab110.ab110Search.chkdd != "" && vmab110.ab110Search.chkdd != undefined) {
                vmab110.searchQuery += "chkdd =" + vmab110.ab110Search.chkdd + " and ";
            }
            if (vmab110.ab110Search.payee != "" && vmab110.ab110Search.payee != undefined) {
                vmab110.searchQuery += "payee like '%" + vmab110.ab110Search.payee + "%' and ";
            }
            if (vmab110.ab110Search.bankinfo != "" && vmab110.ab110Search.bankinfo != undefined) {
                vmab110.searchQuery += "bankinfo like '%" + vmab110.ab110Search.bankinfo + "%' and ";
            }
            if (vmab110.ab110Search.swift != "" && vmab110.ab110Search.swift != undefined) {
                vmab110.searchQuery += "swift like '%" + vmab110.ab110Search.swift + "%' and ";
            }

            vmab110.searchQuery = vmab110.searchQuery.substring(0, vmab110.searchQuery.length - 4);
            if (vmab110.searchQuery != "" && vmab110.searchQuery != undefined) {
                vmab110.paging.currentPage = 1;
            }
            getab110();
        }

        function getab110() {
            dataContext.get('/api/ab110?filterExpression=' + vmab110.searchQuery + '&sortExpression=' + vmab110.sortExp + '&pageIndex=' + vmab110.paging.currentPage + '&pageSize=' + vmab110.paging.pageSize + '&rowsCount=0').then(function (data) {
                vmab110.ab110List = data.ab110List;
                vmab110.paging.totalPages = parseInt(data.RowsCount) == parseInt(vmab110.paging.pageSize) ? 1 : Math.floor(((parseInt(data.RowsCount) / parseInt(vmab110.paging.pageSize)) + 1));
                vmab110.paging.totalRecords = data.RowsCount;
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

                vmab110.sortExp = $($event.currentTarget).attr("data-colname") + " asc";   //update soring column in sorting exp

            } else {

                $(tds).attr("class", "sorting");  // add sorting class to every td in thead
                $(tds[0]).attr("class", "");   //remove class sorting from action coloumn 
                $(tds[1]).attr("class", "");   //remove class sorting from action coloumn 

                $($event.currentTarget).attr("class", "sorting_desc");   //add asc class in current tag
                vmab110.sortExp = $($event.currentTarget).attr("data-colname") + " desc";   //update soring column in sorting exp
            }

            getab110();
        }

        function selectUnselectAll($event) {
            var chk = $($event.currentTarget);
            if ($(chk).is(":checked")) {
                $("tbody .css-checkbox.lrg").prop("checked", true);
            } else {
                $("tbody .css-checkbox.lrg").prop("checked", false);
            }
        }

        function deleteab110(id) {
            vmab110.isDeleteBtn = true;

            vmab110.ab110DeleteId = id;
            $("#modalTitle").text("ab110 delete");
            $("#modalBody").text("Are you sure you want to delete gkey =" + id);
            $("#commonModal").modal('show');
        };

        function multipleDeleteab110() {
            vmab110.isDeleteBtn = true;
            vmab110.ab110DeleteId = "";
            $.grep($("tbody .css-checkbox.lrg:checked"), function (p, i) {
                vmab110.ab110DeleteId = vmab110.ab110DeleteId + $(p).attr("id") + ",";
            });
            $("#modalTitle").text("ab110 delete");
            $("#modalBody").text("Are you sure you want to delete ab110 =" + vmab110.productDeleteId);
            $("#commonModal").modal('show');
        }

        function confirmDelete() {
            dataContext.deleteData("/api/ab110?id=" + vmab110.ab110DeleteId).then(function (data) {
                vmab110.getab110();
                vmab110.isDeleteBtn = false;

                $("#modalTitle").text("Response message");
                $("#modalBody").text("Successfully deleted.");
                window.location.hash = "#/ab110";
            });
            //}).error(function (data, status) {
            //    $("#commonModal").modal('hide');
            //    alert("Some error occurred try again later");
            //});
        };

        function hideShowSearchPanel() {
            vmab110.isSearch = !vmab110.isSearch;
        };



        function clearSearch() {
			vmab110.ab110Search = {
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
            vmab110.searchQuery = "";
            getab110();
        }
    };
    // End ab110 List function
})();

