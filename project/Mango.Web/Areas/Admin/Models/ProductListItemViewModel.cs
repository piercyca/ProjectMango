using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="Product" />
    /// </summary>
    public class ProductListItemViewModel
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Price { get; set; }
    }
}