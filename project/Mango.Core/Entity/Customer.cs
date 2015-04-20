using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Core.Entity
{
    [Table("Customer")]
    public class Customer
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [Key]
        public int CustomerId { get; set; }

        /// <summary>
        /// Full Name
        /// </summary>
        [Required]
        [StringLength(300)]
        public string FullName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Username, loosely coupled with OWIN Identity - string IUser.Username, not 
        /// the GUID IUser.Id. May be null to support guest checkout.
        /// </summary>
        public string Username { get; set; }

        public Customer()
        {
            DateCreated = DateTime.Now;
        }
    }
}
