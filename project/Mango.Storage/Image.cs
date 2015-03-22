using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Storage
{
    public class Image
    {
        private string _connectionString { get; set; }

        public Image()
        {
            _connectionString = ConfigurationManager.AppSettings["ImageBlobConnectionString"];
        }

        public static void Storage()
        {
        }
    }
}
