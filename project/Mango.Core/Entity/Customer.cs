﻿using System;
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
        /// First Name
        /// </summary>
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
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
