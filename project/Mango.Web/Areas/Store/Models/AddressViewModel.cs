using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mango.Core.Entity;

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
            AddressType = AddressType.Unknown;
        }

        /// <summary>
        /// Address Id
        /// </summary>
        [Key]
        public int AddressId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public AddressStatus Status { get; set; }

        /// <summary>
        /// Address Type
        /// </summary>
        public AddressType AddressType { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Display(Name = "First Name")]
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Display(Name = "Phone")]
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Address Line 1
        /// </summary>
        [Display(Name = "Address Line 1")]
        
        [StringLength(200)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address Line 2
        /// </summary>
        [Display(Name = "Address Line 2")]
        [StringLength(200)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [Required]
        [StringLength(50)]
        public string State { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Zip { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        /// <summary>
        /// Shorthand Format
        /// </summary>
        [ReadOnly(true)]
        public string Shorthand { get; set; }

        /// <summary>
        /// Print Format
        /// </summary>
        [ReadOnly(true)]
        public string Print { get; set; }

        /// <summary>
        /// Flat Address Format
        /// </summary>
        [ReadOnly(true)]
        public string FlatAddress { get; set; }
    }
}