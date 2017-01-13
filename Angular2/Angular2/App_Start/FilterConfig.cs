using System.Web;
using System.Web.Mvc;
using Angular2.Helper;

namespace Angular2
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AjaxMessagesFilter());
			//filters.Add(new RequireHttpsAttribute());
		}
	}
}
