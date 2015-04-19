using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// Product Image ViewModel for <seealso cref="ProductImage"/>
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