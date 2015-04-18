using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mango.Core.Web.Checkout
{
    /// <summary>
    /// 
    /// </summary>
    public class PayPalCartModel
    {
        public List<PayPalCartItemModel> CartItems { get; set; }
        public string BuyerName { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get { return (CartItems != null) ? CartItems.Sum(x => x.Amount) : 0; } }

        public PayPalCartModel()
        {
            CartItems = new List<PayPalCartItemModel>();
            BuyerName = string.Empty;
            ShippingAddress = string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PayPalCartItemModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount
        {
            get { return this.Quantity * this.UnitPrice; }
        }
    }


}
