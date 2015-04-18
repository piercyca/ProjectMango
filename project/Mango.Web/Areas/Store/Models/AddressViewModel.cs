using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;
using Mango.Core.Web.Helpers;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// View Model for <seealso cref="Address"/>
    /// </summary>
    public class AddressViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressViewModel()
        {
            Status = AddressStatus.Active;
            AddressType = AddressType.Ship;
            States = UnitedStatesHelper.States;
            Country = "US";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddressViewModel(AddressType addressType)
        {
            Status = AddressStatus.Active;
            AddressType = addressType;
            States = UnitedStatesHelper.States;
            Country = "US";
        }

        /// <summary>
        /// Address Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int AddressId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public AddressStatus Status { get; set; }

        /// <summary>
        /// Address Type
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public AddressType AddressType { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        [StringLength(150)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(150)]
        public string LastName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Required]
        [Display(Name = "Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Address Line 1
        /// </summary>
        [Required]
        [StringLength(200)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address Line 2
        /// </summary>
        [StringLength(200)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// County
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "County")]
        public string County { get; set; }

        /// <summary>
        /// State Abbreviation
        /// </summary>
        [Required]
        [StringLength(10)]
        [Display(Name = "State")]
        public string State { get; set; }

        /// <summary>
        /// Select list items for states
        /// </summary>
        public IEnumerable<SelectListItem> States { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        [Required]
        [StringLength(10)]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        /// <summary>
        /// Country
        /// use ISO codes, see: http://en.wikipedia.org/wiki/ISO_3166-1
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string Country { get; set; }
    }
}