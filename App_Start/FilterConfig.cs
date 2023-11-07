using System.Web;
using System.Web.Mvc;

namespace inventory_ManagementSystem
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
