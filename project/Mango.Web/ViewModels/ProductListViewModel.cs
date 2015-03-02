using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.ViewModels
{
    /// View model for <see cref="Product" />
    public class ProductListViewModel
    {
        public IEnumerable<ProductListItemViewModel> ProductList { get; set; } 

        public IEnumerable<SelectListItem> SortBy { get; set; }

        public ProductListViewModel(string selectedSort)
        {
            SortBy = new SelectList(new[]{
                       new SelectListItem{ Text="Name", Value="Name"},
                       new SelectListItem{ Text="Code", Value="Code"}}, "Text", "Value", selectedSort);

        }

        public ProductListViewModel()
        {
            
        }
    }
}