using System;
using System.Web.Mvc;

namespace web.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AjaxOnlyAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // If this is not an AJAX request then send the requestor to the no access error page
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.Result = new RedirectResult("~/Error/NoAccess");
        }
    }
}