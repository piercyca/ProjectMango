using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Store.Models
{
    public class ProductImageViewModel
    {
        /// <summary>
        /// Url to image
        /// </summary>
        [ReadOnly(true)]
        public string Url { get; set; }
    }
}