using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage;

namespace Mango.Storage
{
    public static class Image
    {
        private static string _connectionString = ConfigurationManager.AppSettings["ImageBlobConnectionString"];
        private static readonly string _container = "images";

        /// <summary>
        /// Uploads to a Azure Storage Blob
        /// </summary>
        /// <param name="localPath">Local Path</param>
        /// <param name="contentType">Content Type</param>
        /// <returns>Url to file</returns>
        public static string Upload(string localPath, string contentType)
        {
            var blobStorage = new BlobStorage(_container, "DefaultEndpointsProtocol=https;AccountName=mangoassets;AccountKey=VoyVSRbfxISONW6I0yq+p7ptlU5EZkh/VNKIcJ5nPnxjCRCX6iEju+Agi53JyXQ2mWp1sMKHaRCHiBs7XPv+0g==");
            var blobUrl = blobStorage.CreateBlockBlob(Path.GetFileName(localPath), contentType, File.ReadAllBytes(localPath));
            //File.Delete(localPath);
            return blobUrl;
        }
    }
}
