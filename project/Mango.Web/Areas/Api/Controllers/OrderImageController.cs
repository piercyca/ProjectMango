using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using Mango.Core.Web;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Areas.Api.Controllers
{
    public class OrderImageController : ApiController
    {
        // GET: api/orderimage
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/orderimage/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/orderimage
        public string Post([FromBody]JObject jsonData)
        {
            dynamic json = jsonData;
            var value = json.value;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                var base64Data = Regex.Match(value.ToString(), @"data:image/(?<type>.+?),(?<data>.+)");
                var binData = Convert.FromBase64String(base64Data.Groups["data"].Value);
                try
                {
                    return Storage.BlobImage.Upload("order-images", string.Format("image/{0}", "png"), "png", binData);
                }
                catch (Exception ex)
                {
                    var errorMessage = new StringBuilder();
                    errorMessage.AppendLine("Order Image Post Failed");
                    errorMessage.AppendLine("ControllerMethod: Api > OrderImage.Post()");
                    ExceptionLogger.Log(errorMessage, ex);
                }
            }
            return "error";
        }

        // PUT: api/orderimage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/orderimage/5
        public void Delete(int id)
        {
        }
    }
}
