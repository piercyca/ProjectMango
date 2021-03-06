﻿using System;
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
            Customer = new Customer();
            ShippingAddress = new Address();
        }

        /// <summary>
        /// Shipping Address entity
        /// </summary>
        public Address ShippingAddress { get; set; }
        
        /// <summary>
        /// Customer entity
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Convert to Paypal Model
        /// </summary>
        /// <returns></returns>
        public PayPalCartModel ConvertToPaypalModel()
        {
            var payPalModel = new PayPalCartModel();
            foreach (var item in Items)
            {
                var payPalCartItemModel = new PayPalCartItemModel
                {
                    ProductId = item.Product.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };
                payPalModel.CartItems.Add(payPalCartItemModel);
            }
            return payPalModel;
        }

        public void ClearCart()
        {
            Items = new List<CartItemModel>();
            Customer = new Customer();
            ShippingAddress = new Address();
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
        public string OrderImage { get; set; }
    }
}
