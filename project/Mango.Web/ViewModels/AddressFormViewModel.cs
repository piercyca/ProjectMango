using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.ViewModels
{
    /// <summary>
    /// View Model. Maps to <see cref="Address"/>
    /// </summary>
    public class AddressFormViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int AddressId { get; set; }

        public AddressType AddressType { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Company")]
        [StringLength(100)]
        public string Company { get; set; }

        [Display(Name = "Attn")]
        [StringLength(100)]
        public string Attn { get; set; }

        [Display(Name = "Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [StringLength(50)]
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [StringLength(10)]
        [Display(Name = "Zip")]
        [Required]
        public string Zip { get; set; }

        [StringLength(50)]
        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }
    }
}