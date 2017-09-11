using System;
using System.Linq;
using System.Collections.Generic;

using System.Web;
using System.Web.Mvc;

using web.Models;
using web.Attributes;

namespace web.Controllers
{
    public class GiftCertificatesController : Controller
    {
        //
        // GET: /GiftCertificates/

        public ActionResult Index()
        {
            return View(new GiftCertificate());
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Purchase(GiftCertificate gc)
        {
            return Json(new { Success = true });
        }
    }
}