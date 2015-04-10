using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;
using Mango.Web.Areas.Store.Models;

namespace Mango.Web.Areas.Admin.Models
{
    public class OrderListViewModel
    {
        /// <summary>
        /// Order Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int OrderId { get; set; }

        /// <summary>
        /// Customer Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int CustomerId { get; set; }

        /// <summary>
        /// Shipping Address Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int ShipAddressId { get; set; }

        /// <summary>
        /// Billing Address Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int? BillAddressId { get; set; }

        /// <summary>
        /// Total Amount
        /// </summary>
        [ReadOnly(true)]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        public CustomerViewModel Customer { get; set; }

        /// <summary>
        /// Billing Address
        /// </summary>
        public virtual AddressViewModel BillAddress { get; set; }

        /// <summary>
        /// Shipping Address
        /// </summary>
        public virtual AddressViewModel ShipAddress { get; set; }

		/// <summary>
		/// Date Created
		/// </summary>
		public DateTime DateCreated { get; set; }

		/// <summary>
		/// Order Items
		/// </summary>
		public IEnumerable<OrderLineItem> OrderLineItems { get; set; }
    }
}