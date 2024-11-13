using System.Web;
using System.Web.Mvc;

namespace web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, bool isDebugEnabled)
        {
            filters.Add(new HandleErrorAttribute());

            if (!isDebugEnabled) filters.Add(new RequireHttpsAttribute());
        }
    }
}