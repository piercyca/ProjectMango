using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Azure.Storage;
using Microsoft.WindowsAzure.Storage;

namespace Mango.Storage
{
    public static class BlobImage
    {
        private static readonly string _connectionString = ConfigurationManager.AppSettings["Azure:ImageBlobConnectionString"];

        /// <summary>
        /// Uploads to a Azure Storage Blob
        /// </summary>
        /// <param name="container">blob container name</param>
        /// <param name="contentType">Content Type</param>
        /// <param name="localPath">Local Path</param>
        /// <returns>Url to file</returns>
        public static string Upload(string container, string contentType, string localPath)
        {
            var filename = Path.GetFileName(localPath);
            var bytes = File.ReadAllBytes(localPath);
            var blobUrl = new BlobStorage(container, _connectionString).CreateBlockBlob(filename, contentType, bytes);
            return blobUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container">blob container name</param>
        /// <param name="contentType">Content Type</param>
        /// /// <param name="extension">File extension</param>
        /// <param name="bytes">Byte array</param>
        /// <returns></returns>
        public static string Upload(string container, string contentType, string extension, byte[] bytes)
        {
            if (!extension.StartsWith("."))
            {
                extension = string.Format(".{0}", extension);
            }
            var fileName = string.Format("{0}{1}", Guid.NewGuid().ToString("N"), extension);
            var blobUrl = new BlobStorage(container, _connectionString).CreateBlockBlob(fileName, contentType, bytes);
            return blobUrl;
        }


        /// <summary>
        /// Downloads blob from Azure Storage blob
        /// </summary>
        /// <param name="container"></param>
        /// <param name="blobId"></param>
        /// <returns></returns>
        public static BlobImageDetails Download(string container, string blobId)
        {
            var storageAccount = CloudStorageAccount.Parse(_connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference(container);
            var blob = blobContainer.GetBlobReferenceFromServer(blobId);
            var memoryStream = new MemoryStream();
            blob.DownloadToStream(memoryStream);
            return new BlobImageDetails
            {
                Bytes = ReadFully(memoryStream),
                ContentType = blob.Properties.ContentType,
                Container = container
            };
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];

            input.Position = 0; // Add this line to set the input stream position to 0

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        } 
    }
}
