using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// Form View Model for <see cref="Organization"/>
    /// </summary>
    public class OrganizationFormViewModel
    {
        /// <summary>
        /// Organization Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Name")] 
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Abbreviation
        /// </summary>
        [DisplayName("Abbreviation")] 
        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Primary Logo Image
        /// </summary>
        [DisplayName("Primary Logo Image")] 
        public string PrimaryLogoImage { get; set; }
    }
}