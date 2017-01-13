(function () {
    // Start ab120 List function
    var ListControllerId = 'ab120List';
    angular.module('app').controller(ListControllerId, 
		['$scope', '$http', '$filter', '$location', '$routeParams', '$route', 'common', 'dataContext', 'authService', ListController]);

    function ListController($scope, $http, $filter, $location, $routeParams, $route, common, dataContext, authService) {
        if (!authService.authentication.isAuth) {
            $location.path('/login');
            return;
        }
        
        var vmab120 = this;

        //Search properties
        vmab120.ab120Search = {
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
        vmab120.isSearch = false;
        vmab120.searchQuery = "";
        // Properties
        vmab120.ab120List = [];     // the collection of all ab120
        vmab120.paging = {
            currentPage: 1,
            pageSize: 10,
            totalPages: 0,
            pagingSizeValues: [5, 10, 20, 30, 50],
			totalRecords: 0
        };  // paging related properties 

        vmab120.sortExp = "ba015gkey asc";

        vmab120.isDeleteBtn = false;              // hide show delete btn in dialog message
        vmab120.ab120DeleteId = 0;

        vmab120.getab120 = getab120;        // Function binding 
        vmab120.sorting = sorting;
        vmab120.selectUnselectAll = selectUnselectAll;
        vmab120.deleteab120 = deleteab120;
        vmab120.confirmDelete = confirmDelete;
        vmab120.multipleDeleteab120 = multipleDeleteab120;
        vmab120.hideShowSearchPanel = hideShowSearchPanel;
        vmab120.getSearchab120 = getSearchab120;
        vmab120.clearSearch = clearSearch;

        activate();

        function activate() {
			getab120();
			
        }

        function pageNumberDone() {
            $("#pageNoddl").select2("val", vmab120.paging.currentPage);
        }

        function getSearchab120() {
            vmab120.searchQuery = "";

            if (vmab120.ab120Search.gkey != "" && vmab120.ab120Search.gkey != undefined) {
                vmab120.searchQuery += "gkey like '%" + vmab120.ab120Search.gkey + "%' and ";
            }
            if (vmab120.ab120Search.ba015gkey != "" && vmab120.ab120Search.ba015gkey != undefined) {
                vmab120.searchQuery += "ba015gkey like '%" + vmab120.ab120Search.ba015gkey + "%' and ";
            }
            if (vmab120.ab120Search.ba015gkey1 != "" && vmab120.ab120Search.ba015gkey1 != undefined) {
                vmab120.searchQuery += "ba015gkey1 like '%" + vmab120.ab120Search.ba015gkey1 + "%' and ";
            }
            if (vmab120.ab120Search.ac002gkey1 != "" && vmab120.ab120Search.ac002gkey1 != undefined) {
                vmab120.searchQuery += "ac002gkey1 like '%" + vmab120.ab120Search.ac002gkey1 + "%' and ";
            }
            if (vmab120.ab120Search.ac002gkey2 != "" && vmab120.ab120Search.ac002gkey2 != undefined) {
                vmab120.searchQuery += "ac002gkey2 like '%" + vmab120.ab120Search.ac002gkey2 + "%' and ";
            }
            if (vmab120.ab120Search.ac002gkey3 != "" && vmab120.ab120Search.ac002gkey3 != undefined) {
                vmab120.searchQuery += "ac002gkey3 like '%" + vmab120.ab120Search.ac002gkey3 + "%' and ";
            }
            if (vmab120.ab120Search.ac002gkey4 != "" && vmab120.ab120Search.ac002gkey4 != undefined) {
                vmab120.searchQuery += "ac002gkey4 like '%" + vmab120.ab120Search.ac002gkey4 + "%' and ";
            }
            if (vmab120.ab120Search.ab041gkey1 != "" && vmab120.ab120Search.ab041gkey1 != undefined) {
                vmab120.searchQuery += "ab041gkey1 like '%" + vmab120.ab120Search.ab041gkey1 + "%' and ";
            }
            if (vmab120.ab120Search.accountno1 != "" && vmab120.ab120Search.accountno1 != undefined) {
                vmab120.searchQuery += "accountno1 like '%" + vmab120.ab120Search.accountno1 + "%' and ";
            }
            if (vmab120.ab120Search.ab041gkey2 != "" && vmab120.ab120Search.ab041gkey2 != undefined) {
                vmab120.searchQuery += "ab041gkey2 like '%" + vmab120.ab120Search.ab041gkey2 + "%' and ";
            }
            if (vmab120.ab120Search.accountno2 != "" && vmab120.ab120Search.accountno2 != undefined) {
                vmab120.searchQuery += "accountno2 like '%" + vmab120.ab120Search.accountno2 + "%' and ";
            }
            if (vmab120.ab120Search.clsdd != "" && vmab120.ab120Search.clsdd != undefined) {
                vmab120.searchQuery += "clsdd =" + vmab120.ab120Search.clsdd + " and ";
            }
            if (vmab120.ab120Search.mmend != "" && vmab120.ab120Search.mmend != undefined) {
                vmab120.searchQuery += "mmend =" + vmab120.ab120Search.mmend + " and ";
            }
            if (vmab120.ab120Search.chkdd != "" && vmab120.ab120Search.chkdd != undefined) {
                vmab120.searchQuery += "chkdd =" + vmab120.ab120Search.chkdd + " and ";
            }
            if (vmab120.ab120Search.payee != "" && vmab120.ab120Search.payee != undefined) {
                vmab120.searchQuery += "payee like '%" + vmab120.ab120Search.payee + "%' and ";
            }
            if (vmab120.ab120Search.bankinfo != "" && vmab120.ab120Search.bankinfo != undefined) {
                vmab120.searchQuery += "bankinfo like '%" + vmab120.ab120Search.bankinfo + "%' and ";
            }
            if (vmab120.ab120Search.swift != "" && vmab120.ab120Search.swift != undefined) {
                vmab120.searchQuery += "swift like '%" + vmab120.ab120Search.swift + "%' and ";
            }

            vmab120.searchQuery = vmab120.searchQuery.substring(0, vmab120.searchQuery.length - 4);
            if (vmab120.searchQuery != "" && vmab120.searchQuery != undefined) {
                vmab120.paging.currentPage = 1;
            }
            getab120();
        }

        function getab120() {
            dataContext.get('/api/ab120?filterExpression=' + vmab120.searchQuery + '&sortExpression=' + vmab120.sortExp + '&pageIndex=' + vmab120.paging.currentPage + '&pageSize=' + vmab120.paging.pageSize + '&rowsCount=0').then(function (data) {
                vmab120.ab120List = data.ab120List;
                vmab120.paging.totalPages = parseInt(data.RowsCount) == parseInt(vmab120.paging.pageSize) ? 1 : Math.floor(((parseInt(data.RowsCount) / parseInt(vmab120.paging.pageSize)) + 1));
                vmab120.paging.totalRecords = data.RowsCount;
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

                vmab120.sortExp = $($event.currentTarget).attr("data-colname") + " asc";   //update soring column in sorting exp

            } else {

                $(tds).attr("class", "sorting");  // add sorting class to every td in thead
                $(tds[0]).attr("class", "");   //remove class sorting from action coloumn 
                $(tds[1]).attr("class", "");   //remove class sorting from action coloumn 

                $($event.currentTarget).attr("class", "sorting_desc");   //add asc class in current tag
                vmab120.sortExp = $($event.currentTarget).attr("data-colname") + " desc";   //update soring column in sorting exp
            }

            getab120();
        }

        function selectUnselectAll($event) {
            var chk = $($event.currentTarget);
            if ($(chk).is(":checked")) {
                $("tbody .css-checkbox.lrg").prop("checked", true);
            } else {
                $("tbody .css-checkbox.lrg").prop("checked", false);
            }
        }

        function deleteab120(id) {
            vmab120.isDeleteBtn = true;

            vmab120.ab120DeleteId = id;
            $("#modalTitle").text("ab120 delete");
            $("#modalBody").text("Are you sure you want to delete gkey =" + id);
            $("#commonModal").modal('show');
        };

        function multipleDeleteab120() {
            vmab120.isDeleteBtn = true;
            vmab120.ab120DeleteId = "";
            $.grep($("tbody .css-checkbox.lrg:checked"), function (p, i) {
                vmab120.ab120DeleteId = vmab120.ab120DeleteId + $(p).attr("id") + ",";
            });
            $("#modalTitle").text("ab120 delete");
            $("#modalBody").text("Are you sure you want to delete ab120 =" + vmab120.productDeleteId);
            $("#commonModal").modal('show');
        }

        function confirmDelete() {
            dataContext.deleteData("/api/ab120?id=" + vmab120.ab120DeleteId).then(function (data) {
                vmab120.getab120();
                vmab120.isDeleteBtn = false;

                $("#modalTitle").text("Response message");
                $("#modalBody").text("Successfully deleted.");
                window.location.hash = "#/ab120";
            });
            //}).error(function (data, status) {
            //    $("#commonModal").modal('hide');
            //    alert("Some error occurred try again later");
            //});
        };

        function hideShowSearchPanel() {
            vmab120.isSearch = !vmab120.isSearch;
        };



        function clearSearch() {
			vmab120.ab120Search = {
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
            vmab120.searchQuery = "";
            getab120();
        }
    };
    // End ab120 List function
})();

