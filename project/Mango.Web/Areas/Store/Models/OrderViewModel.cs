﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Store.Models
{
    public class OrderViewModel
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
    }
}