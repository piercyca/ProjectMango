using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="Organization" />
    /// </summary>
    public class OrganizationListItemViewModel
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}