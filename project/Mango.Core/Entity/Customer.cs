using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace Mango.Core.Entity
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
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
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        //TODO figure out how to relate
        //[ForeignKey("UserId")]
        //public virtual User User { get; set; } 

        public Customer()
        {
            DateCreated = DateTime.Now;
        }
    }
}
