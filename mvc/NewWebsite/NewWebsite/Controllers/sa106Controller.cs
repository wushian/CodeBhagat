#region History
/************************CREATION HISTORY*********************************
 * Created By		: CodeBhagat v1.0
 * Created Date		: 2017/1/13
 * Purpose			: This is an MVC Controller class that calls methods to perform 
 *					  Data Layer operations and returns to View
 * *********************UPDATION HISTORY******************************
 * 
 * Updated By		Updated Date			Comments
 * ------------------------------------------------------------
*/
#endregion

#region Using Statements	
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using jqMvcGrid.Models;
using OfficeOpenXml;		// Namespace from EP Plus component
using OfficeOpenXml.Style;	// Namespace from EP Plus component
using NewWebsite.Models;
#endregion

namespace NewWebsite
{
	[OutputCache(NoStore = true, Duration = 0)]
    public class sa106Controller : Controller
    {
        private Isa106Repository _repository = new sa106Repository();

        //
        // GET: /sa106/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int page, int rows, string search, string sidx, string sord)
        {
            int rowsCount = 0;
			string filterExpression = (search != null ? "gkey like '%" + search + "%'" : string.Empty);
			/*
            List<sa106Data> objsa106List = CodeBhagat.DAL.sa106.GetList(filterExpression, sidx + " " + sord, page, rows, out rowsCount);

            var model = from objsa106 in objsa106List.AsQueryable()
                        select new
                        {
                            Edit = "<a style='color:#5c87b2' href='" + "sa106/Edit/" + objsa106.gkey + "'>Edit</a>",
                            Details = "<a style='color:#5c87b2' href='" + "sa106/Details/" + objsa106.gkey + "'>Details</a>",
                            						gkey = objsa106.gkey,
						orddate = objsa106.orddate,
						mr200gkey = objsa106.mr200gkey,
						issuedate = objsa106.issuedate,
						pono = objsa106.pono,
						salesno = objsa106.salesno,
						returnno = objsa106.returnno,
						returndate = objsa106.returndate,
						deliveryno = objsa106.deliveryno,
						rettype = objsa106.rettype,
						xtype = objsa106.xtype,
						ba205gkey = objsa106.ba205gkey,
						pickupdate = objsa106.pickupdate,
						canceldate = objsa106.canceldate,
						ba100gkey = objsa106.ba100gkey,
						ba102gkey = objsa106.ba102gkey,
						ba103gkey = objsa106.ba103gkey,
						ba119gkey = objsa106.ba119gkey,
						ba118gkey = objsa106.ba118gkey,
						ba121gkey = objsa106.ba121gkey,
						ba104gkey = objsa106.ba104gkey,
						ba209gkey = objsa106.ba209gkey,
						returnamt = objsa106.returnamt,
						canadaamt = objsa106.canadaamt,
						freightamt = objsa106.freightamt,
						proceamt = objsa106.proceamt,
						insuredamt = objsa106.insuredamt,
						pickupamt = objsa106.pickupamt,
						discountamt = objsa106.discountamt,
						vouchersamt = objsa106.vouchersamt,
						reservatamt = objsa106.reservatamt,
						activityamt = objsa106.activityamt,
						totalfreight = objsa106.totalfreight,
						totaltreatment = objsa106.totaltreatment,
						totalinsurance = objsa106.totalinsurance,
						totalamt = objsa106.totalamt,
						pairs = objsa106.pairs,
						remark = objsa106.remark,
						ba005gkey = objsa106.ba005gkey,
						modifydate = objsa106.modifydate,
						revisedate = objsa106.revisedate,
						approve = objsa106.approve,
						aes101gkey = objsa106.aes101gkey,
						ses101gkey = objsa106.ses101gkey,
						es101gkey = objsa106.es101gkey,
						replication_create = objsa106.replication_create,
						replication_update = objsa106.replication_update,
						rownum = objsa106.rownum,
						addproceamt = objsa106.addproceamt,
						lossproceamt = objsa106.lossproceamt,
						virementamt = objsa106.virementamt,
						ba040gkey = objsa106.ba040gkey,
						ba040gkey1 = objsa106.ba040gkey1,
						receivabledate = objsa106.receivabledate,
						receivableamt = objsa106.receivableamt,
						virementdate = objsa106.virementdate,
						salesamt = objsa106.salesamt,
						collchk = objsa106.collchk,
						payfreight = objsa106.payfreight,
						strchk = objsa106.strchk,
						noamount = objsa106.noamount,
						totalamount = objsa106.totalamount,
						ba101gkey = objsa106.ba101gkey,
						remittancedate = objsa106.remittancedate,
						remittancetime = objsa106.remittancetime,

                        };
			var pagedList = model.ToPagedList(0, rows); // new PagedList<T>(model, page - 1, rows);
            JqGridData objGridData = new JqGridData()
            {
                Page = page, //pagedModel.PageIndex + 1,
                Records = rowsCount, //pagedModel.TotalItemCount,
                Rows = from record in pagedList
                       select record,
                Total = ((int) (rowsCount/rows)) + 1, //pagedModel.PageCount,
                UserData = null
            };
			*/
			
			// DropdownList
			// ViewData["[COLUMN_NAME]"] = new SelectList(users, "[COLUMN_NAME]", "[COLUMN_NAME_DISPLAY]", selectedUserId.Value); 
			
			// Enable below code if you are using Entity Framework
            var repository = new sa106Repository();
            var model = from objsa106 in repository.Index().OrderBy(sidx + " " + sord)
                        select new
                        {
                            Edit = "<a style='color:#5c87b2' href='" + "sa106/Edit/" + objsa106.gkey + "'>Edit</a>",
                            Details = "<a style='color:#5c87b2' href='" + "sa106/Details/" + objsa106.gkey + "'>Details</a>",
                            						gkey = objsa106.gkey,
						orddate = objsa106.orddate,
						mr200gkey = objsa106.mr200gkey,
						issuedate = objsa106.issuedate,
						pono = objsa106.pono,
						salesno = objsa106.salesno,
						returnno = objsa106.returnno,
						returndate = objsa106.returndate,
						deliveryno = objsa106.deliveryno,
						rettype = objsa106.rettype,
						xtype = objsa106.xtype,
						ba205gkey = objsa106.ba205gkey,
						pickupdate = objsa106.pickupdate,
						canceldate = objsa106.canceldate,
						ba100gkey = objsa106.ba100gkey,
						ba102gkey = objsa106.ba102gkey,
						ba103gkey = objsa106.ba103gkey,
						ba119gkey = objsa106.ba119gkey,
						ba118gkey = objsa106.ba118gkey,
						ba121gkey = objsa106.ba121gkey,
						ba104gkey = objsa106.ba104gkey,
						ba209gkey = objsa106.ba209gkey,
						returnamt = objsa106.returnamt,
						canadaamt = objsa106.canadaamt,
						freightamt = objsa106.freightamt,
						proceamt = objsa106.proceamt,
						insuredamt = objsa106.insuredamt,
						pickupamt = objsa106.pickupamt,
						discountamt = objsa106.discountamt,
						vouchersamt = objsa106.vouchersamt,
						reservatamt = objsa106.reservatamt,
						activityamt = objsa106.activityamt,
						totalfreight = objsa106.totalfreight,
						totaltreatment = objsa106.totaltreatment,
						totalinsurance = objsa106.totalinsurance,
						totalamt = objsa106.totalamt,
						pairs = objsa106.pairs,
						remark = objsa106.remark,
						ba005gkey = objsa106.ba005gkey,
						modifydate = objsa106.modifydate,
						revisedate = objsa106.revisedate,
						approve = objsa106.approve,
						aes101gkey = objsa106.aes101gkey,
						ses101gkey = objsa106.ses101gkey,
						es101gkey = objsa106.es101gkey,
						replication_create = objsa106.replication_create,
						replication_update = objsa106.replication_update,
						rownum = objsa106.rownum,
						addproceamt = objsa106.addproceamt,
						lossproceamt = objsa106.lossproceamt,
						virementamt = objsa106.virementamt,
						ba040gkey = objsa106.ba040gkey,
						ba040gkey1 = objsa106.ba040gkey1,
						receivabledate = objsa106.receivabledate,
						receivableamt = objsa106.receivableamt,
						virementdate = objsa106.virementdate,
						salesamt = objsa106.salesamt,
						collchk = objsa106.collchk,
						payfreight = objsa106.payfreight,
						strchk = objsa106.strchk,
						noamount = objsa106.noamount,
						totalamount = objsa106.totalamount,
						ba101gkey = objsa106.ba101gkey,
						remittancedate = objsa106.remittancedate,
						remittancetime = objsa106.remittancetime,

                            //CategoryName = "<a href=''>" + objsa106.CategoryName + "</a>",
                        };
            return Json(model.ToJqGridData(page, rows, null, search,
                new[] {  "gkey", "orddate", "mr200gkey", "issuedate", "pono", "salesno", "returnno", "returndate", "deliveryno", "rettype", "xtype", "ba205gkey", "pickupdate", "canceldate", "ba100gkey", "ba102gkey", "ba103gkey", "ba119gkey", "ba118gkey", "ba121gkey", "ba104gkey", "ba209gkey", "returnamt", "canadaamt", "freightamt", "proceamt", "insuredamt", "pickupamt", "discountamt", "vouchersamt", "reservatamt", "activityamt", "totalfreight", "totaltreatment", "totalinsurance", "totalamt", "pairs", "remark", "ba005gkey", "modifydate", "revisedate", "approve", "aes101gkey", "ses101gkey", "es101gkey", "replication_create", "replication_update", "rownum", "addproceamt", "lossproceamt", "virementamt", "ba040gkey", "ba040gkey1", "receivabledate", "receivableamt", "virementdate", "salesamt", "collchk", "payfreight", "strchk", "noamount", "totalamount", "ba101gkey", "remittancedate", "remittancetime" }), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /sa106/Details/5
        public ActionResult Details(string id)
        {
            return View(_repository.Details(id));
        }

        //
        // GET: /sa106/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /sa106/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(sa106Data objsa106Data, FormCollection collection)
        {
            try
            {
                // Validate
                if (!Validate(objsa106Data))
                    return View();

                // Create
                if (_repository.Create(objsa106Data))
                    return View();

                // Success
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /sa106/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_repository.Details(id));
        }

        //
        // POST: /sa106/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(sa106Data objsa106Data, FormCollection collection)
        {
            try
            {
                // Validate
                if (!Validate(objsa106Data))
                    return View(objsa106Data);

                // Edit
                if (!_repository.Edit(objsa106Data))
                    return View(objsa106Data);

                //  Success
                return RedirectToAction("Index");
            }
            catch
            {
                return View(objsa106Data);
            }
        }

        protected bool Validate(sa106Data objsa106Data)
        {
			// Add your business rules here
            //if (string.IsNullOrEmpty(objCategories.CategoryName))
            //    ModelState.AddModelError("CategoryName", "CategoryName is required!");
            return ModelState.IsValid;
        }
		
		#region Export To Excel - using EP Plus
		// This method uses EP Plus component to export the data to Excel
		// Please visit http://epplus.codeplex.com/ for more information/download latest updates for this component
		public ActionResult ExportToExcel()
		{
			DataSet ds = new DataSet();
			ds = NewWebsite.Models.sa106.GetData();

			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				//Create the worksheet
				ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add(ds.Tables[0].TableName);

				//Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
				ws.Cells["A1"].LoadFromDataTable(ds.Tables[0], true);

				for (int r = 1, c = 1; c <= ds.Tables[0].Columns.Count; c++)
				{
					ws.Cells[r, c].Style.Font.Bold = true;
					ws.Cells[r, c].Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
					ws.Cells[r, c].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
					ws.Cells[r, c].Style.Font.Color.SetColor(Color.White);
					ws.Column(c).AutoFit();
				}

				//Write it back to the client
				Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				Response.AddHeader("content-disposition", "attachment;filename=Categories.xlsx");
				Response.BinaryWrite(excelPackage.GetAsByteArray());
				Response.End();
			}

			return View();
		}
		#endregion	
    }
}
	