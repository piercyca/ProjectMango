using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="ProductCategory" />
    /// </summary>
    public class ProductCategoryListItemViewModel
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public string Keywords { get; set; }
    }
}