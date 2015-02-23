using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Core.Data
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }

        public int ShipAddressId { get; set; }
        
        /// <summary>
        /// Billing Address Id
        /// </summary>
        public int? BillAddressId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("BillAddressId")]
        public virtual Address BillAddress { get; set; }

        [ForeignKey("ShipAddressId")]
        public virtual Address ShipAddress { get; set; }

        public Order()
        {
            DateCreated = DateTime.Now;
        }
    }
}
