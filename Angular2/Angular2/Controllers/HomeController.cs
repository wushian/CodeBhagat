using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angular2.Helper;

namespace Angular2.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpPost]
		public ActionResult Index(string message)
		{
			this.ShowMessage(MessageType.Success, message);
			return View();
		}

		public ActionResult RedirectWithWarning()
		{
			this.ShowMessage(MessageType.Warning, "This warning is displayed after the redirect.", true);
			return RedirectToAction("Index");
		}

		public ActionResult Partial()
		{
			this.ShowMessage(MessageType.Error, "Error message while displaying a partial view.");
			return PartialView("PartialView");
		}

		public ActionResult JsonData()
		{
			this.ShowMessage(MessageType.Warning, "Warning message while returning JSON data");

			var result = new JsonResult();
			result.Data = new { Code = 584, Description = "Some arbitrary JSON data", TheDate = DateTime.Now.ToString() };
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}
	}
}