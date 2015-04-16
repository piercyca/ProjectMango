using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Core.Web.Checkout
{
    public interface ICartService
    {
        CartModel GetCartModel();
        void AddItem(Product product, List<ProductImage> productImages,  int quantity, decimal price, string configuration);
        void UpdateItemQuantity(int index, int quantity);
        void RemoveItem(int index);
        PaypalCartModel ConvertToPaypalModel(); 
    }

    /// <summary>
    /// Service to access cart session object
    /// </summary>
    public class CartService : ICartService
    {
        private const string _sessionId = "Cart";
        private static CartModel _cart
        {
            get
            {
                if (HttpContext.Current.Session[_sessionId] == null)
                {
                    HttpContext.Current.Session[_sessionId] = new CartModel();
                }
                return (CartModel)HttpContext.Current.Session[_sessionId];
            }
            set
            {
                if (value != null)
                {
                    HttpContext.Current.Session[_sessionId] = value;
                }
            }
        }

        public CartModel GetCartModel()
        {
            return _cart;
        }

        public void AddItem(Product product, List<ProductImage> productImages, int quantity, decimal price, string configuration)
        {
            var cartItem = new CartItemModel
            {
                Product = product,
                ProductImages = productImages,
                Quantity = quantity,
                UnitPrice = price,
                Configuration = configuration
            };
            _cart.Items.Add(cartItem);
        }

        public void UpdateItemQuantity(int index, int quantity)
        {
            if (_cart.Items.Count <= index)
                return;

            _cart.Items[index].Quantity = quantity;
        }

        public void RemoveItem(int index)
        {
            if (_cart.Items.Count <= index)
                return;
            _cart.Items.RemoveAt(index);
        }

        public PaypalCartModel ConvertToPaypalModel()
        {
            return _cart.ConvertToPaypalModel();
        }
    }
}
