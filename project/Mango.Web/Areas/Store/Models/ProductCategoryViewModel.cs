using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// View Model for Product Category page
    /// </summary>
    public class ProductCategoryViewModel
    {
        public List<ProductCategoryDetailViewModel> Categories { get; set; }
        public ProductCategoryDetailViewModel SelectedCategory { get; set; }
        public List<ProductDetailViewModel> Products { get; set; } 
    }
}