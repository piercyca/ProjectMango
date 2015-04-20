using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// View Model for <seealso cref="Customer"/>
    /// Used by customer signup form and/or account creation
    /// </summary>
    public class CustomerViewModel
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int CustomerId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Display(Name = "Full Name")]
        [Required]
        [StringLength(300)]
        public string FullName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [EmailAddress]
        [StringLength(200)]
        [HiddenInput(DisplayValue = false)]
        public string Username { get; set; }
    }
}