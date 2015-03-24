using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View Model. Maps to <see cref="Customer"/>
    /// </summary>
    public class CustomerFormViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
		[RegularExpression(@"(^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$)", ErrorMessage = "Incorrect email format.")]
        public string Email { get; set; }

		[Required]
		public string UserId { get; set; }
    }
}