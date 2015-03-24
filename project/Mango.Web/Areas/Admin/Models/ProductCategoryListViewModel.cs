using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// View model for <see cref="ProductCategory" />
    public class ProductCategoryListViewModel
    {
        public IEnumerable<ProductCategoryListItemViewModel> ProductCategoryList { get; set; } 

        public IEnumerable<SelectListItem> SortBy { get; set; }

        public ProductCategoryListViewModel(string selectedSort)
        {
            SortBy = new SelectList(new[]{
                       new SelectListItem{ Text="Name", Value="Name"},
                       new SelectListItem{ Text="UrlSlug", Value="UrlSlug"}}, "Text", "Value", selectedSort);

        }

        public ProductCategoryListViewModel()
        {
            
        }
    }
}