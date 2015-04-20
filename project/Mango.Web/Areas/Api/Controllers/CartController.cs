using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Mango.Core.Service;
using Mango.Core.Web.Checkout;
using Mango.Web.Areas.Store.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Areas.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CartController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly ICartService _cartService;

        public CartController() { }
        public CartController(IProductService productService, IProductImageService productImageService, ICartService cartService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _cartService = cartService;
        }

        /// <summary>
        /// /api/cart/additem
        /// 
        /// Adds item to cart
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns
        public AddToCartModel AddItem([FromBody]AddToCartModel cartItem)
        {
            var product = _productService.GetProduct(cartItem.ProductId);
            if (product != null && product.ProductId > 0)
            {
                var productImages = _productImageService.GetProductImages(product.ProductId).ToList();
                _cartService.AddItem(product, productImages, cartItem.Quantity, cartItem.UnitPrice, cartItem.Configuration);
            }
            return cartItem;
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        /// <summary>
        /// /api/cart/removeitem
        /// 
        /// Removes Item from cart
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object RemoveItem([FromBody]int index)
        {
            _cartService.RemoveItem(index);
            return new { index = index }; 
        }

        /// <summary>
        /// /api/cart/updateitemquantity
        /// 
        /// Updates item quanity
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public object UpdateItemQuantity(JObject jsonData)
        {
            dynamic json = jsonData;
            int index = json.index;
            int quantity = json.quantity;
            _cartService.UpdateItemQuantity(index, quantity);
            return new { index, quantity };
        }
    }
}
