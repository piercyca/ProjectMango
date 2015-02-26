using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Admin.ViewModels
{
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
    }
}