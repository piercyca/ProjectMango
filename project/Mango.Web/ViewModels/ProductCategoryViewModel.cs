using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.ViewModels
{
    /// <summary>
    /// View model for <see cref="ProductCategory" />
    /// </summary>
    public class ProductCategoryViewModel
    {
        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}