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
//using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
//using jqMvcGrid.Models;
using OfficeOpenXml;		// Namespace from EP Plus component
using OfficeOpenXml.Style;	// Namespace from EP Plus component
using NewWebsite.Models;
using NewWebsite.Helper;
#endregion

namespace NewWebsite
{
	[Authorize]
	[OutputCache(NoStore = true, Duration = 0)]
    public class sa106aController : Controller
    {
        //private Isa106aRepository _repository = new sa106aRepository();

        //
        // GET: /sa106a/
        public ActionResult Index()
        {
			PopulateLookups();
            return View(new sa106aData());
        }

        public ActionResult GetList(int pageIndex, int pageSize, string sortExpression)
        {
            int rowsCount = 0;
            string filterExpression = GetFilterExpression();
			if (string.IsNullOrEmpty(sortExpression))
				sortExpression = "gkey asc";
            List<sa106aData> objsa106aList = NewWebsite.Models.sa106a.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount).ToList();
			var model = from objsa106a in objsa106aList.AsQueryable()
						select new
						{
						gkey = objsa106a.gkey,
						serialno = objsa106a.serialno,
						sa106gkey = objsa106a.sa106gkey,
						ba101gkey = objsa106a.ba101gkey,
						ba110gkey = objsa106a.ba110gkey,
						ba113gkey = objsa106a.ba113gkey,
						mr200gkey = objsa106a.mr200gkey,
						mr200agkey = objsa106a.mr200agkey,
						ba120gkey = objsa106a.ba120gkey,
						ba121gkey = objsa106a.ba121gkey,
						ba106gkey = objsa106a.ba106gkey,
						shipmentdate = objsa106a.shipmentdate,
						canceldate = objsa106a.canceldate,
						cancelreason = objsa106a.cancelreason,
						activityid = objsa106a.activityid,
						activityname = objsa106a.activityname,
						quantity = objsa106a.quantity,
						nodisprice = objsa106a.nodisprice,
						noamount = objsa106a.noamount,
						disprice = objsa106a.disprice,
						cancelqty = objsa106a.cancelqty,
						cancelamt = objsa106a.cancelamt,
						outquantity = objsa106a.outquantity,
						retquantity = objsa106a.retquantity,
						prepono = objsa106a.prepono,
						mr210gkey = objsa106a.mr210gkey,
						mr210agkey = objsa106a.mr210agkey,
						remark = objsa106a.remark,
						replication_create = objsa106a.replication_create,
						replication_update = objsa106a.replication_update,
						inventoryQty = objsa106a.inventoryQty,
						outstockQty = objsa106a.outstockQty,
						tstdqty = objsa106a.tstdqty,
						ba126gkey = objsa106a.ba126gkey,
						webgkey = objsa106a.webgkey,
						canadaamt = objsa106a.canadaamt,
						ba117gkey = objsa106a.ba117gkey,

						};
			var objGridData = new
            {
                data = from record in model
					   select record,
				pageSize = rowsCount
            };

			var result = Json(objGridData, JsonRequestBehavior.AllowGet);
	        result.MaxJsonLength = int.MaxValue;
			return result;
        }
		
        public ActionResult List(int page, int rows, string search, string sidx, string sord)
        {
            int rowsCount = 0;
			string filterExpression = (search != null ? "gkey like '%" + search + "%'" : string.Empty);
            List<sa106aData> objsa106aList = NewWebsite.Models.sa106a.GetList(filterExpression, sidx + " " + sord, page, rows, out rowsCount);

            var model = from objsa106a in objsa106aList.AsQueryable()
                        select new
                        {
                            Edit = "<a style='color:#5c87b2' href='" + "sa106a/Edit/" + objsa106a.gkey + "'>Edit</a>",
                            Details = "<a style='color:#5c87b2' href='" + "sa106a/Details/" + objsa106a.gkey + "'>Details</a>",
                            						gkey = objsa106a.gkey,
						serialno = objsa106a.serialno,
						sa106gkey = objsa106a.sa106gkey,
						ba101gkey = objsa106a.ba101gkey,
						ba110gkey = objsa106a.ba110gkey,
						ba113gkey = objsa106a.ba113gkey,
						mr200gkey = objsa106a.mr200gkey,
						mr200agkey = objsa106a.mr200agkey,
						ba120gkey = objsa106a.ba120gkey,
						ba121gkey = objsa106a.ba121gkey,
						ba106gkey = objsa106a.ba106gkey,
						shipmentdate = objsa106a.shipmentdate,
						canceldate = objsa106a.canceldate,
						cancelreason = objsa106a.cancelreason,
						activityid = objsa106a.activityid,
						activityname = objsa106a.activityname,
						quantity = objsa106a.quantity,
						nodisprice = objsa106a.nodisprice,
						noamount = objsa106a.noamount,
						disprice = objsa106a.disprice,
						cancelqty = objsa106a.cancelqty,
						cancelamt = objsa106a.cancelamt,
						outquantity = objsa106a.outquantity,
						retquantity = objsa106a.retquantity,
						prepono = objsa106a.prepono,
						mr210gkey = objsa106a.mr210gkey,
						mr210agkey = objsa106a.mr210agkey,
						remark = objsa106a.remark,
						replication_create = objsa106a.replication_create,
						replication_update = objsa106a.replication_update,
						inventoryQty = objsa106a.inventoryQty,
						outstockQty = objsa106a.outstockQty,
						tstdqty = objsa106a.tstdqty,
						ba126gkey = objsa106a.ba126gkey,
						webgkey = objsa106a.webgkey,
						canadaamt = objsa106a.canadaamt,
						ba117gkey = objsa106a.ba117gkey,

                        };
			var objGridData = new 
            {
                Page = page,
                Records = rowsCount,
                Rows = from record in model
                       select record,
                Total = ((int) (rowsCount/rows)) + 1,
            };

            var result = Json(objGridData, JsonRequestBehavior.AllowGet);
	        result.MaxJsonLength = int.MaxValue;
			return result;


			// Enable below code if you are using Entity Framework
			/*
            var repository = new sa106aRepository();
            var model = from objsa106a in repository.Index().OrderBy(sidx + " " + sord)
                        select new
                        {
                            Edit = "<a style='color:#5c87b2' href='" + "sa106a/Edit/" + objsa106a.gkey + "'>Edit</a>",
                            Details = "<a style='color:#5c87b2' href='" + "sa106a/Details/" + objsa106a.gkey + "'>Details</a>",
                            						gkey = objsa106a.gkey,
						serialno = objsa106a.serialno,
						sa106gkey = objsa106a.sa106gkey,
						ba101gkey = objsa106a.ba101gkey,
						ba110gkey = objsa106a.ba110gkey,
						ba113gkey = objsa106a.ba113gkey,
						mr200gkey = objsa106a.mr200gkey,
						mr200agkey = objsa106a.mr200agkey,
						ba120gkey = objsa106a.ba120gkey,
						ba121gkey = objsa106a.ba121gkey,
						ba106gkey = objsa106a.ba106gkey,
						shipmentdate = objsa106a.shipmentdate,
						canceldate = objsa106a.canceldate,
						cancelreason = objsa106a.cancelreason,
						activityid = objsa106a.activityid,
						activityname = objsa106a.activityname,
						quantity = objsa106a.quantity,
						nodisprice = objsa106a.nodisprice,
						noamount = objsa106a.noamount,
						disprice = objsa106a.disprice,
						cancelqty = objsa106a.cancelqty,
						cancelamt = objsa106a.cancelamt,
						outquantity = objsa106a.outquantity,
						retquantity = objsa106a.retquantity,
						prepono = objsa106a.prepono,
						mr210gkey = objsa106a.mr210gkey,
						mr210agkey = objsa106a.mr210agkey,
						remark = objsa106a.remark,
						replication_create = objsa106a.replication_create,
						replication_update = objsa106a.replication_update,
						inventoryQty = objsa106a.inventoryQty,
						outstockQty = objsa106a.outstockQty,
						tstdqty = objsa106a.tstdqty,
						ba126gkey = objsa106a.ba126gkey,
						webgkey = objsa106a.webgkey,
						canadaamt = objsa106a.canadaamt,
						ba117gkey = objsa106a.ba117gkey,

                            //CategoryName = "<a href=''>" + objsa106a.CategoryName + "</a>",
                        };
            return Json(model.ToJqGridData(page, rows, null, search,
                new[] { "CategoryName", "Description" }));
			*/
        }

		public void PopulateLookups()
		{
			
		}

        //
        // GET: /sa106a/Details/5
        public ActionResult Details(string id)
        {
			ViewBag.ErrorMsg = Session["ErrorMsg"];
            return View(NewWebsite.Models.sa106a.GetDetailsByID(id));
        }

        //
        // GET: /sa106a/Create
        public ActionResult Create()
        {
			PopulateLookups();
            return View(new NewWebsite.Models.sa106aData());
        }

        //
        // POST: /sa106a/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(sa106aData objsa106aData, FormCollection collection)
        {
            try
            {
                // Validate
                //if (!Validate(objsa106aData))
                //    return View();
				
				if (ModelState.IsValid)
				{
	                // Create
	                if (NewWebsite.Models.sa106a.Add(objsa106aData) != string.Empty)
					{
						this.ShowMessage(MessageType.Success, "The record was saved successfully!!!", true);
		                return RedirectToAction("Index");
					}
				}
            }
            catch(Exception ex)
            {
				Session["ErrorMsg"] = "Error: Please try again!!!<br />" + ex.Message;
				ViewBag.ErrorMsg = Session["ErrorMsg"];
            }
			PopulateLookups();
			return View(objsa106aData);
        }

        //
        // GET: /sa106a/Edit/5
        public ActionResult Edit(string id)
        {
			sa106aData objsa106a = NewWebsite.Models.sa106a.GetDetailsByID(id);
			PopulateLookups();
			return View(objsa106a);
        }

        //
        // POST: /sa106a/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(sa106aData objsa106aData, FormCollection collection)
        {
            try
            {
                // Validate
                //if (!Validate(objsa106aData))
                //    return View(objsa106aData);
				
				if (ModelState.IsValid)
				{
	                if (NewWebsite.Models.sa106a.Update(objsa106aData))
					{
						this.ShowMessage(MessageType.Success, "The record was saved successfully!!!", true);
		                return RedirectToAction("Index");
					}
				}
            }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = "Error: Please try again!!!<br />" + ex.Message;
				ViewBag.ErrorMsg = Session["ErrorMsg"];
            }
			PopulateLookups();
			return View(objsa106aData);
        }

		public ActionResult Delete(int id)
		{
			bool success = false;
			try
			{
				success = NewWebsite.Models.sa106a.Delete(id.ToString());
			}
			catch(Exception ex)
			{
				Session["ErrorMsg"] = "Error: Please try again!!!<br />" + ex.Message;
				success = false;
			}
			if (success)
			{
				this.ShowMessage(MessageType.Success, "The record was deleted successfully!!!", true);
				return RedirectToAction("Index");
			}
			else
				return RedirectToAction("Details", "sa106a", new { id = id });
		}
		
        protected bool Validate(sa106aData objsa106aData)
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
			ds = NewWebsite.Models.sa106a.GetData();

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
		
        private string GetFilterExpression()
        {
            var filterKeys = Request.Params.AllKeys.AsQueryable().Where(p => p.Contains("filter")).ToList();
            var query = string.Empty;
            for (int i = 0; i < filterKeys.Count / 3; i++)
            {
                if (i > 0)
                    query += " AND ";

                query += Request.Params.Get("filter[filters][" + i + "][field]") + " ";
                if (Request.Params.Get("filter[filters][" + i + "][operator]") == "startswith")
                {
                    query += "like '" + Request.Params.Get("filter[filters][" + i + "][value]").ToString() + "%'";
                }
                else if (Request.Params.Get("filter[filters][" + i + "][operator]") == "contains")
                {
                    query += "like '%" + Request.Params.Get("filter[filters][" + i + "][value]").ToString() + "%'";
                }
                else
                {
                    query += searchOperator(Request.Params.Get("filter[filters][" + i + "][operator]")) + " '";
                    query += Request.Params.Get("filter[filters][" + i + "][value]").ToString() + "' ";
                }
            }
            return query;
        }

		private string searchOperator(string condition)
        {
            switch (condition)
            {
                case "eq":
                    return "=";
                case "neq":
                    return "<>";
                default:
                    return "";
            }
        }
    }
}
	