using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Storage
{
    public class BlobImageDetails
    {
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
        public string Container { get; set; }

        public BlobImageDetails()
        {
            Bytes = null;
            ContentType = string.Empty;
            Container = string.Empty;
        }
    }
}
