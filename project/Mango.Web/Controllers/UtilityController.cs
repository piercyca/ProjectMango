using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Web.Controllers
{
    public partial class UtilityController : Controller
    {
        // GET: Utility
        [HttpGet]
        public virtual FileStreamResult BlobImage(string container, string blobId)
        {
            var blob = Storage.BlobImage.Download(container, blobId);
            return new FileStreamResult(new MemoryStream(blob.Bytes), blob.ContentType);
        }
    }
}