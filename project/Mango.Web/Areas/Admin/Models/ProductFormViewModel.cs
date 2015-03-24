using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="Product" />
    /// </summary>
    public class ProductFormViewModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        /// <summary>
        /// Product Category Id
        /// </summary>
        [DisplayName("Product Category")] 
        [Required]
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Select list items for product categories dropdown
        /// </summary>
        public IEnumerable<SelectListItem> ProductCategories { get; set; }

            /// <summary>
        /// Code
        /// </summary>
        [DisplayName("Code")]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }
    }
}