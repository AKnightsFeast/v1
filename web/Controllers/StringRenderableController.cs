using System;
using System.IO;
using System.Web.Mvc;

namespace web.Controllers
{
    public abstract class StringRenderableController : Controller
    {
        public string PartialViewToString(string viewName, object model = null)
        {
            this.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);

                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(this.ControllerContext, viewResult.View);

                return sw.ToString();
            }
        }

        public bool IsAjax()
        {
            return ControllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}