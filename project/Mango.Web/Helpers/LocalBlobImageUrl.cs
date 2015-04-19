using System;


namespace Mango.Core.Common
{
    public class LocalBlobImageUrl
    {
        public static string Url(string blobUrl)
        {
            var uri = new Uri(blobUrl);
            return "bi" + uri.LocalPath;
        }

    }
}
