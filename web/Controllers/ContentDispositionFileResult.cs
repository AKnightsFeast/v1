using System;
using System.Web.Mvc;
using System.Net.Mime;

namespace web.Controllers
{
    public class ContentDispositionFileResult : FileContentResult
    {
        private const string ContentDispositionHeaderName = "Content-Disposition";

        public ContentDispositionFileResult(byte[] fileContents, string contentType, ContentDisposition contentDisposition) : base(fileContents, contentType)
        {
            ContentDisposition = contentDisposition; // check for null or invalid ctor arguments
        }

        public ContentDisposition ContentDisposition { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            // check for null or invalid method argument
            ContentDisposition.FileName = ContentDisposition.FileName ?? FileDownloadName;
            var response = context.HttpContext.Response;
            response.ContentType = ContentType;
            response.AddHeader(ContentDispositionHeaderName, ContentDisposition.ToString());
            WriteFile(response);
        }
    }
}