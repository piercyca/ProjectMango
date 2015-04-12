﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// CartCustomer View Model
    /// </summary>
    public class CartCustomerViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public AddressViewModel BillingAddress { get; set; }
        public AddressViewModel ShippingAddress { get; set; }
    }
}