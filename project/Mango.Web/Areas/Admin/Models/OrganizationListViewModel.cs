using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// View model for <see cref="Organization" />
    public class OrganizationListViewModel
    {
        public IEnumerable<OrganizationListItemViewModel> OrganizationList { get; set; } 

        public IEnumerable<SelectListItem> SortBy { get; set; }

        public OrganizationListViewModel(string selectedSort)
        {
            SortBy = new SelectList(new[]{
                       new SelectListItem{ Text="Name", Value="Name"},
                       new SelectListItem{ Text="Abbreviation", Value="Abbreviation"}}, "Text", "Value", selectedSort);

        }

        public OrganizationListViewModel()
        {
            
        }
    }
}