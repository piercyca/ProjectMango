using System.Collections.Generic;
using System.Web;
using Mango.Core.Entity;

namespace Mango.Core.Web.Checkout
{
    public interface ICartService
    {
        CartModel GetCartModel();
        void AddItem(Product product, List<ProductImage> productImages,  int quantity, decimal price, string configuration, string orderImage);
        void UpdateItemQuantity(int index, int quantity);
        void RemoveItem(int index);
        PayPalCartModel ConvertToPaypalModel();
        void ClearCart();
        int Count();
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

        /// <summary>
        /// Get cart model from session
        /// </summary>
        /// <returns></returns>
        public CartModel GetCartModel()
        {
            return _cart;
        }

        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productImages"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="configuration"></param>
        /// <param name="orderImage"></param>
        public void AddItem(Product product, List<ProductImage> productImages, int quantity, decimal price, string configuration, string orderImage)
        {
            _cart.Items.Add(new CartItemModel
            {
                Product = product,
                ProductImages = productImages,
                Quantity = quantity,
                UnitPrice = price,
                Configuration = configuration,
                OrderImage = orderImage
            });
        }

        /// <summary>
        /// Update Item quantity
        /// </summary>
        /// <param name="index"></param>
        /// <param name="quantity"></param>
        public void UpdateItemQuantity(int index, int quantity)
        {
            if (_cart.Items.Count <= index)
            {
                return;
            }

            if (quantity == 0)
            {
                RemoveItem(index);
                return;
            }
            _cart.Items[index].Quantity = quantity;
        }

        /// <summary>
        /// Remove item from cart
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(int index)
        {
            if (_cart.Items.Count <= index)
            {
                return;
            }
            _cart.Items.RemoveAt(index);
        }

        /// <summary>
        /// Converts cart to paypal cart
        /// </summary>
        /// <returns></returns>
        public PayPalCartModel ConvertToPaypalModel()
        {
            return _cart.ConvertToPaypalModel();
        }

        /// <summary>
        /// Empty cart
        /// </summary>
        public void ClearCart()
        {
            _cart.ClearCart();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _cart.Items.Count;
        }
    }
}
