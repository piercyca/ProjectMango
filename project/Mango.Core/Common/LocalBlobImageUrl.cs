using System;


namespace Mango.Core.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class LocalBlobImageUrl
    {
        public static string Url(string blobUrl)
        {
            return string.Format("/bi{0}", new Uri(blobUrl).LocalPath);
        }

    }
}
