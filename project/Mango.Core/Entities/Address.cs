using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace Mango.Core.Entities
{
    [Table("Address")]
    public class Address
    {
        public Address()
        {
            DateCreated = DateTime.UtcNow;
            Status = AddressStatus.Active;
            AddressType = AddressType.Unknown;
        }

        [Key]
        public int AddressId { get; set; }

        public AddressStatus Status { get; set; }

        public AddressType AddressType { get; set; }

        [Display(Name = "Nickname")]
        [StringLength(100)]
        public string Nickname { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100)]
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
        [Display(Name = "Street Address")]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(2)]
        public string Country { get; set; }

        public DateTime DateCreated { get; set; }

        [NotMapped]
        public string Shorthand
        {
            get
            {
                string result = "";

                if (!String.IsNullOrEmpty(Nickname))
                    result += Nickname + ": ";

                if (!String.IsNullOrEmpty(FirstName))
                    result += FirstName + " ";

                if (!String.IsNullOrEmpty(LastName))
                    result += LastName + " ";

                if (!String.IsNullOrEmpty(Company))
                    result += Company + " ";

                if (!String.IsNullOrEmpty(Attn))
                    result += "Attn: " + Attn + " ";

                result += AddressLine1;

                if (!String.IsNullOrEmpty(AddressLine2))
                    result += " " + AddressLine2;

                result += ", " + City + ", " + State + " " + Zip + " " + Country;

                return result.Trim();
            }
        }

        [NotMapped]
        public string Print
        {
            get
            {
                string result = "";

                if (!String.IsNullOrEmpty(FirstName) || !String.IsNullOrEmpty(LastName))
                    result += (FirstName + " " + LastName).Trim() + Environment.NewLine;

                if (!String.IsNullOrEmpty(Company))
                    result += Company + Environment.NewLine;

                if (!String.IsNullOrEmpty(Attn))
                    result += "Attn: " + Attn + Environment.NewLine;

                result += AddressLine1 + Environment.NewLine;

                if (!String.IsNullOrEmpty(AddressLine2))
                    result += AddressLine2 + Environment.NewLine;

                result += City + ", " + State + " " + Zip;

                if (!String.IsNullOrEmpty(Country) && Country.ToUpper() != "US")
                    result += Environment.NewLine + Country;

                return result;
            }
        }

        [NotMapped]
        public string FlatAddress
        {
            get
            {
                return (AddressLine1 + " " + (String.IsNullOrEmpty(AddressLine2) ? "" : AddressLine2 + " ") + (String.IsNullOrEmpty(City) ? "" : City + ", ") + State + " " + Zip + (String.IsNullOrEmpty(Country) ? "" : ", " + Country)).Trim();
            }
        }

        public Address Copy()
        {
            var newaddr = new Address();

            newaddr.AddressType = this.AddressType;
            newaddr.FirstName = this.FirstName;
            newaddr.LastName = this.LastName;
            newaddr.Company = this.Company;
            newaddr.Attn = this.Attn;
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
