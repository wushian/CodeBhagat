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
    public class sa106dController : Controller
    {
        //private Isa106dRepository _repository = new sa106dRepository();

        //
        // GET: /sa106d/
        public ActionResult Index()
        {
			PopulateLookups();
            return View(new sa106dData());
        }

        public ActionResult GetList(int pageIndex, int pageSize, string sortExpression)
        {
            int rowsCount = 0;
            string filterExpression = GetFilterExpression();
			if (string.IsNullOrEmpty(sortExpression))
				sortExpression = "gkey asc";
            List<sa106dData> objsa106dList = NewWebsite.Models.sa106d.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount).ToList();
			var model = from objsa106d in objsa106dList.AsQueryable()
						select new
						{
						gkey = objsa106d.gkey,
						serialno = objsa106d.serialno,
						sa106gkey = objsa106d.sa106gkey,
						ba212gkey = objsa106d.ba212gkey,
						agument = objsa106d.agument,
						amount = objsa106d.amount,
						remark = objsa106d.remark,
						replication_create = objsa106d.replication_create,
						replication_update = objsa106d.replication_update,

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
            List<sa106dData> objsa106dList = NewWebsite.Models.sa106d.GetList(filterExpression, sidx + " " + sord, page, rows, out rowsCount);

            var model = from objsa106d in objsa106dList.AsQueryable()
                        select new
                        {
                            Edit = "<a style='color:#5c87b2' href='" + "sa106d/Edit/" + objsa106d.gkey + "'>Edit</a>",
                            Details = "<a style='color:#5c87b2' href='" + "sa106d/Details/" + objsa106d.gkey + "'>Details</a>",
                            						gkey = objsa106d.gkey,
						serialno = objsa106d.serialno,
						sa106gkey = objsa106d.sa106gkey,
						ba212gkey = objsa106d.ba212gkey,
						agument = objsa106d.agument,
						amount = objsa106d.amount,
						remark = objsa106d.remark,
						replication_create = objsa106d.replication_create,
						replication_update = objsa106d.replication_update,

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
            var repository = new sa106dRepository();
            var model = from objsa106d in repository.Index().OrderBy(sidx + " " + sord)
                        select new
                        {
                            Edit = "<a style='color:#5c87b2' href='" + "sa106d/Edit/" + objsa106d.gkey + "'>Edit</a>",
                            Details = "<a style='color:#5c87b2' href='" + "sa106d/Details/" + objsa106d.gkey + "'>Details</a>",
                            						gkey = objsa106d.gkey,
						serialno = objsa106d.serialno,
						sa106gkey = objsa106d.sa106gkey,
						ba212gkey = objsa106d.ba212gkey,
						agument = objsa106d.agument,
						amount = objsa106d.amount,
						remark = objsa106d.remark,
						replication_create = objsa106d.replication_create,
						replication_update = objsa106d.replication_update,

                            //CategoryName = "<a href=''>" + objsa106d.CategoryName + "</a>",
                        };
            return Json(model.ToJqGridData(page, rows, null, search,
                new[] { "CategoryName", "Description" }));
			*/
        }

		public void PopulateLookups()
		{
			
		}

        //
        // GET: /sa106d/Details/5
        public ActionResult Details(string id)
        {
			ViewBag.ErrorMsg = Session["ErrorMsg"];
            return View(NewWebsite.Models.sa106d.GetDetailsByID(id));
        }

        //
        // GET: /sa106d/Create
        public ActionResult Create()
        {
			PopulateLookups();
            return View(new NewWebsite.Models.sa106dData());
        }

        //
        // POST: /sa106d/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(sa106dData objsa106dData, FormCollection collection)
        {
            try
            {
                // Validate
                //if (!Validate(objsa106dData))
                //    return View();
				
				if (ModelState.IsValid)
				{
	                // Create
	                if (NewWebsite.Models.sa106d.Add(objsa106dData) != string.Empty)
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
			return View(objsa106dData);
        }

        //
        // GET: /sa106d/Edit/5
        public ActionResult Edit(string id)
        {
			sa106dData objsa106d = NewWebsite.Models.sa106d.GetDetailsByID(id);
			PopulateLookups();
			return View(objsa106d);
        }

        //
        // POST: /sa106d/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(sa106dData objsa106dData, FormCollection collection)
        {
            try
            {
                // Validate
                //if (!Validate(objsa106dData))
                //    return View(objsa106dData);
				
				if (ModelState.IsValid)
				{
	                if (NewWebsite.Models.sa106d.Update(objsa106dData))
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
			return View(objsa106dData);
        }

		public ActionResult Delete(int id)
		{
			bool success = false;
			try
			{
				success = NewWebsite.Models.sa106d.Delete(id.ToString());
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
				return RedirectToAction("Details", "sa106d", new { id = id });
		}
		
        protected bool Validate(sa106dData objsa106dData)
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
			ds = NewWebsite.Models.sa106d.GetData();

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
	