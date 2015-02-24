using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Mango.Core.Media
{
    /// <summary>
    /// API for accessing and uploading images and files in an Azure Storage blob.
    /// </summary>
    public class AssetManager
    {
        private CloudStorageAccount _storageAccount { get; set; }
        private CloudBlobClient _blobClient { get; set; }

        /// <summary>
        /// Constructor. 
        /// Created Blob client based on app.config settings.
        /// </summary>
        public AssetManager()
        {
            _storageAccount = ConfigurationManager.AppSettings["AzureStorageUseDevelopment"] == "true" ? CloudStorageAccount.DevelopmentStorageAccount : new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["AzureStorageAccountName"], ConfigurationManager.AppSettings["AzureStorageAccountKey"]), true);
            _blobClient = _storageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Saves a file to an Azure Blob
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="contentType"></param>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public string UploadFile(Stream stream, string contentType, string containerName, string blobName)
        {
            var container = _blobClient.GetContainerReference(containerName);

            if (container.CreateIfNotExists())
            {
                var permissions = container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(permissions);
            }

            var blob = container.GetBlockBlobReference(blobName);
            blob.Properties.ContentType = contentType;
            blob.UploadFromStream(stream);

            return blob.Uri.ToString();
        }

        /// <summary>
        /// Checks if blob exists
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public bool Exists(string containerName, string blobName)
        {
            var container = _blobClient.GetContainerReference(containerName);
            var blob = container.GetBlockBlobReference(blobName);

            return blob.Exists();
        }

        /// <summary>
        /// Deletes a blob
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        public void DeleteFile(string containerName, string blobName)
        {
            var container = _blobClient.GetContainerReference(containerName);
            var blob = container.GetBlockBlobReference(blobName);
            
            blob.Delete();
        }
    }
}
