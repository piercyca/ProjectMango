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
        /// Organization Images
        /// </summary>
        [DisplayName("Organization Images")]
        public IEnumerable<OrganizationImageFormViewModel> OrganizationImages { get; set; }

        /// <summary>
        /// Organization Images string, for saving, populated by JavaScript on the client
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string OrganizationImagesString { get; set; }


        public UploadImageViewModel UploadOrganizationImageViewModel { get; set; }

        public OrganizationFormViewModel()
        {
            UploadOrganizationImageViewModel = new UploadImageViewModel("modalUploadOrganizationImage");
        }
    }
}