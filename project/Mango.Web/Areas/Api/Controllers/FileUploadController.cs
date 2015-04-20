using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mango.Web.Areas.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FileUploadController : ApiController
    {
        public Task<IEnumerable<string>> Post()
        {
            //throw new Exception("Custom error thrown for script error handling test!");
            if (Request.Content.IsMimeMultipartContent())
            {
                //Simulate large file upload
                System.Threading.Thread.Sleep(5000);

                CustomMultipartFormDataStreamProvider streamProvider = new CustomMultipartFormDataStreamProvider(Path.GetTempPath());
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    }

                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        // upload to blob storage
                        var blobUrl = Storage.BlobImage.Upload("images", i.Headers.ContentType.ToString(), i.LocalFileName);
                        //return "File saved as " + blobUrl + " (" + info.Length + ") (" + i.Headers.ContentType + ")";
                        return blobUrl;
                    });
                    return fileInfo;

                });
                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
            }
        }
    }

    #region Multipart form provider class

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        {

        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var guid = Guid.NewGuid().ToString("N");
            string fileName;
            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                fileName = guid + Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
            }
            else
            {
                fileName = guid + ".data";
            }
            return fileName;
        }
    }

    #endregion
}
