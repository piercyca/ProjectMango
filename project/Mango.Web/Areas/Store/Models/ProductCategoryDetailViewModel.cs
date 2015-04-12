using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// View Model for <seealso cref="ProductCategory"/> detail
    /// </summary>
    public class ProductCategoryDetailViewModel
    {
        [ReadOnly(true)]
        public int ProductCategoryId { get; set; }

        [ReadOnly(true)]
        public string Name { get; set; }

        [ReadOnly(true)]
        public string Description { get; set; }

        [ReadOnly(true)]
        public string UrlSlug { get; set; }

        [ReadOnly(true)]
        public string Keywords { get; set; }
    }
}