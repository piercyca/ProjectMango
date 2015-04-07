using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View model for <see cref="OrganizationImage" />
    /// </summary>
    public class OrganizationImageFormViewModel
    {
        /// <summary>
        /// Url to image
        /// </summary>
        [Required]
        [Url]
        public string Url { get; set; }

        public UploadImageViewModel UploadImageViewModel { get; set; }
    }
}