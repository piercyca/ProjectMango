using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="ProductImage" />
    /// </summary>
    public class ProductImageFormViewModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Sort Order
        /// </summary>
        [Required]
        public int SortOrder { get; set; }

        /// <summary>
        /// Url to image
        /// </summary>
        [Required]
        [Url]
        public string Url { get; set; }
    }
}