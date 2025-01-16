using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Collections.Generic;

using System.Web;
using System.Web.Mvc;

using PdfSharp.Pdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;

using web.Attributes;
using web.Contexts;
using web.Utilities;

using web.Models;
using web.Models.Enums;

namespace web.Controllers
{
    public class AssessmentController : Controller
    {
        public ActionResult Index()
        {
            return View(new Assessment());
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Assessment form)
        {
            try
            {
                if (form != null && ModelState.IsValid)
                {
                    using (var db = new AssessmentContext())
                    {
                        db.Assessments.Add(form);
                        db.SaveChanges();
                    }

                    Email.Send("system@aknightsfeast.com", "New Assessment", "A new assessment form has been submitted!");

                    return Json(new {
                        Success = true,
                        RedirectUrl = Url.Action("", "Home"),
                        Modal = new {
                            Title = "Thanks!",
                            Message = "<p>Your assessment has been submitted successfully!<p><p>Once Chef Laura has reviewed it she will get back to you shortly!</p>"
                        }
                    });
                }

                return Json(new {
                    Success = false,
                    Modal = new {
                        Title = "Oh No!",
                        Message = "<p>Your assessment was invalid.</p><p>Please fix the errors causing this and resubmit.</p>"
                    }
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Success = false,
                    Modal = new
                    {
                        Title = "Oh No!",
                        Message = "<p>There was an error submitting your assessment.</p><p>Please try resubmitting at a later time.</p>"
                    }
                });
            }
        }

        [NoCache]
        public ActionResult All()
        {
            return View();
        }

        [NoCache]
        [Authorize]
        public ActionResult ViewAll()
        {
            var assessments = new List<Assessment>();

            using (var db = new AssessmentContext())
            {
                assessments = db.Assessments.Include("People").OrderByDescending(a => a.CreationDate).ToList();
            }

            return View(assessments);
        }

        [NoCache]
        [Authorize]
        public ActionResult Details(int id)
        {
            var assessment = new Assessment();

            using (var db = new AssessmentContext())
            {
                assessment = db.Assessments.Include("People").Include("Pets").FirstOrDefault(a => a.AID == id);
            }

            return View(assessment);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [NoCache]
        [Authorize]
        public ActionResult Print(int id)
        {
            var pdf = new Document();
            var pdfStream = new MemoryStream();
            var pdfRenderer = new PdfDocumentRenderer() { Document = pdf };

            var assessment = new Assessment();

            var fileName = Guid.NewGuid().ToString() + ".pdf";

            using (var db = new AssessmentContext())
            {
                assessment = db.Assessments.Include("People").Include("Pets").FirstOrDefault(a => a.AID == id);

                if (assessment != null)
                {
                    var firstPerson = assessment.People.ToList()[0];
                    fileName = string.Format("Assessment.{0}.{1}.{2}.pdf",
                                              assessment.CreationDate.ToString("yyyyMMdd"),
                                              firstPerson.LastName,
                                              firstPerson.FirstName);
                }
            }

            if (assessment == null)
            {
                var section = pdf.AddSection();
                section.AddParagraph("This assessment could not be retrieved.");
                section.AddParagraph("Please contact the system administrator if there is an issue with this result.");
            }
            else
            {
                var address = assessment.CookingAddress;
                var textFrame = pdf.AddSection().AddTextFrame();
                textFrame.AddParagraph("Address");
                textFrame.AddParagraph(address.Address1);
                if (!string.IsNullOrEmpty(address.Address2)) textFrame.AddParagraph(address.Address2);
                textFrame.AddParagraph(string.Format("{0}, {1} {2}", address.City, address.State, address.ZipCode));
            }

            pdfRenderer.RenderDocument();
            pdfRenderer.Save(pdfStream, true);

            return new ContentDispositionFileResult(pdfStream.ToArray(), "application/pdf", new ContentDisposition() { Inline = true, FileName = fileName });
        }
    }
}