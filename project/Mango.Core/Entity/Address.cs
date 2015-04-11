using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mango.Core.Entity
{
    [Table("Address")]
    public class Address
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Address()
        {
            DateCreated = DateTime.UtcNow;
            Status = AddressStatus.Active;
            AddressType = AddressType.Unknown;
            State = "";
            Country = "US"; // use ISO codes, see: http://en.wikipedia.org/wiki/ISO_3166-1
        }

        /// <summary>
        /// Address Id
        /// </summary>
        [Key]
        public int AddressId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [DefaultValue(0)]
        public AddressStatus Status { get; set; }

        /// <summary>
        /// Address Type
        /// </summary>
        [DefaultValue(0)]
        public AddressType AddressType { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Display(Name = "First Name")]
        [StringLength(150)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Display(Name = "Last Name")]
        [StringLength(150)]
        public string LastName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Display(Name = "Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Address Line 1
        /// </summary>
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
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// State Abbreviation
        /// </summary>
        [StringLength(10)]
        public string State { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        [StringLength(10)]
        public string Zip { get; set; }

        /// <summary>
        /// Country
        /// use ISO codes, see: http://en.wikipedia.org/wiki/ISO_3166-1
        /// </summary>
        [StringLength(50)]
        public string Country { get; set; }

        public DateTime DateCreated { get; set; }

        [NotMapped]
        public string Shorthand
        {
            get
            {
                string result = "";

                if (!String.IsNullOrEmpty(FirstName))
                    result += string.Format("{0} ", FirstName);

                if (!String.IsNullOrEmpty(LastName))
                    result += string.Format("{0} ", LastName);

                result += AddressLine1;

                if (!String.IsNullOrEmpty(AddressLine2))
                    result += string.Format(" {0}", AddressLine2);

                result += string.Format(", {0}, {1} {2} {3}", City, State, Zip, Country);

                return result.Trim();
            }
        }

        [NotMapped]
        public string Print
        {
            get
            {
                string result = "";

                if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
                    result += string.Format("{0}{1}", (FirstName + " " + LastName).Trim(), Environment.NewLine);

                result += string.Format("{0}{1}", AddressLine1, Environment.NewLine);

                if (!string.IsNullOrEmpty(AddressLine2))
                    result += string.Format("{0}{1}", AddressLine2, Environment.NewLine);

                result += string.Format("{0}, {1} {2}", City, State, Zip);

                if (!string.IsNullOrEmpty(Country) && Country.ToUpper() != "US")
                    result += string.Format("{0}{1}", Environment.NewLine, Country);

                return result;
            }
        }

        [NotMapped]
        public string FlatAddress
        {
            get
            {
                return
                    (AddressLine1 + " " +
                     (String.IsNullOrEmpty(AddressLine2) ? "" : string.Format("{0} ", AddressLine2)) +
                     (String.IsNullOrEmpty(City) ? "" : string.Format("{0}, ", City)) + State + " " + Zip +
                     (String.IsNullOrEmpty(Country) ? "" : string.Format(", {0}", Country))).Trim();
            }
        }

        public Address Copy()
        {
            var newaddr = new Address();

            newaddr.AddressType = this.AddressType;
            newaddr.FirstName = this.FirstName;
            newaddr.LastName = this.LastName;
            newaddr.Phone = this.Phone;
            newaddr.AddressLine1 = this.AddressLine1;
            newaddr.AddressLine2 = this.AddressLine2;
            newaddr.City = this.City;
            newaddr.State = this.State;
            newaddr.Zip = this.Zip;
            newaddr.Country = this.Country;

            return newaddr;
        }
    }

    public enum AddressStatus
    {
        Active = 0,
        Deleted = 1,
    }

    public enum AddressType
    {
        Unknown = 0,
        Ship = 1,
        Bill = 2
    }
}
