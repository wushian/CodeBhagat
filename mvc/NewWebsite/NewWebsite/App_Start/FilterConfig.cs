using System.Web;
using System.Web.Mvc;
using NewWebsite.Helper;

namespace NewWebsite
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AjaxMessagesFilter());
		}
	}
}
