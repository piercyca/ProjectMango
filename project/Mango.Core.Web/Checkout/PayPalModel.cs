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
    public class PaypalModel
    {
        public List<CartItemModel> Cart { get; set; }
        public string BuyerName { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalAmount
        {
            get
            {
                if (Cart != null)
                {
                    return Cart.Sum(x => x.Amount);
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class CartItemModel
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
