using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Store.Models
{
    /// <summary>
    /// Address View Model
    /// </summary>
    public class AddressesViewModel
    {
        public AddressViewModel Billing { get; set; }
        public AddressViewModel Shipping { get; set; }
    }
}