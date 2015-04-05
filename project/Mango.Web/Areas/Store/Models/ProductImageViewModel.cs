using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// TODO comment
    /// </summary>
    public class ProductImageViewModel
    {
        /// <summary>
        /// Sort Order
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Url to image
        /// </summary>
        [ReadOnly(true)]
        public string Url { get; set; }
    }
}