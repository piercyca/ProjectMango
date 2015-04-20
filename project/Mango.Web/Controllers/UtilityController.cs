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
        /// <summary>
        /// GET: /bi/{container}/{blobId}
        /// </summary>
        /// <param name="container"></param>
        /// <param name="blobId"></param>
        /// <returns></returns>
        [OutputCache(CacheProfile = "Cache24Hour")]
        [HttpGet]
        public virtual FileStreamResult BlobImage(string container, string blobId)
        {
            var blob = Storage.BlobImage.Download(container, blobId);
            return new FileStreamResult(new MemoryStream(blob.Bytes), blob.ContentType);
        }
    }
}