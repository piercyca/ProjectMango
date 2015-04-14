using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Store.Models
{
    public class AddToCartModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Configuration { get; set; }
    }
}