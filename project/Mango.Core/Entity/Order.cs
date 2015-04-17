using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Core.Entity
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

        /// <summary>
        /// 
        /// </summary>
        public string PayPalOrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayPalOrderConfirmation { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public DateTime? DateShipped { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("BillAddressId")]
        public virtual Address BillAddress { get; set; }

        [ForeignKey("ShipAddressId")]
        public virtual Address ShipAddress { get; set; }

		public virtual IEnumerable<OrderLineItem> OrderLineItems { get; set; }

        public Order()
        {
        }
    }
}
