using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Entity;


namespace Mango.Core.Web.Checkout
{
    /// <summary>
    /// Cart Model
    /// </summary>
    public class CartModel
    {
        /// <summary>
        /// Cart Items
        /// </summary>
        public List<CartItemModel> Items { get; set; }
        /// <summary>
        /// Total Price
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0m;
                foreach (var item in Items)
                {
                    total += item.UnitPrice * item.Quantity;
                }
                return total;
            }
        }

        public CartModel()
        {
            Items = new List<CartItemModel>();
        }

        /// <summary>
        /// Convert to Paypal Model
        /// </summary>
        /// <returns></returns>
        public PaypalCartModel ConvertToPaypalModel()
        {
            var paypalModel = new PaypalCartModel();
            foreach (var item in Items)
            {
                var paypalItemModel = new PayPalCartItemModel
                {
                    ProductId = item.Product.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };
                paypalModel.CartItems.Add(paypalItemModel);
            }
            return paypalModel;
        }
    }

    /// <summary>
    /// Cart Item
    /// </summary>
    public class CartItemModel
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Configuration { get; set; }
    }
}
