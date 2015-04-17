using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Core.Web.Checkout;
using Mango.Web.Areas.Store.Models;
using Microsoft.AspNet.Identity;

namespace Mango.Core.Web.Checkout
{
    public class CheckoutHelper
    {


        /// <summary>
        /// Setup customer
        /// </summary>
        /// <param name="customerService"></param>
        /// <returns></returns>
        public Customer Customer(ICustomerService customerService)
        {
            var customer = new Customer();
            var loggedInUsername = HttpContext.Current.User.Identity.GetUserName();
            if (HttpContext.Current.User.Identity.IsAuthenticated && (!string.IsNullOrEmpty(loggedInUsername)))
            {
                customer = customerService.GetCustomer(loggedInUsername) ?? new Customer { Email = loggedInUsername, Username = loggedInUsername };
            }
            return Mapper.Map<Customer, CustomerViewModel>(customer);
        }

        /// <summary>
        /// Setups shipping address for an order
        /// </summary>
        public AddressViewModel ShippingAddress(CustomerViewModel customer, IOrderService orderService)
        {
            // Setup default addresses
            var shippingAddressViewModel = new AddressViewModel(AddressType.Ship);

            // Get last order addresses
            if (customer.CustomerId > 0)
            {
                // Populate default address
                shippingAddressViewModel.FirstName = customer.FirstName;
                shippingAddressViewModel.LastName = customer.LastName;

                var order = orderService.GetOrdersByCustomer(customer.CustomerId).OrderByDescending(o => o.DateCreated).FirstOrDefault();
                if (order != null)
                {
                    if (order.ShipAddress != null)
                    {
                        shippingAddressViewModel = Mapper.Map<Address, AddressViewModel>(order.ShipAddress);
                    }
                }
            }

            return shippingAddressViewModel;
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <param name="addressService"></param>
        /// <param name="customerService"></param>
        /// <param name="orderService"></param>
        /// <param name="orderLineItemService"></param>
        /// <param name="cartService"></param>
        /// <returns>OrderId</returns>
        public int CreateOrder(Customer customer, Address shippingAddress, 
            IAddressService addressService, 
            ICustomerService customerService,
            IOrderService orderService,
            IOrderLineItemService orderLineItemService,
            ICartService cartService)
        {
            // Check if cart is empty
            var cart = cartService.GetCartModel();
            if (!cart.Items.Any())
            {
                //todo capture error
                return 0;
            }

            // Create or Edit customer
            

            if (customer.CustomerId == 0)
            {
                customerService.CreateCustomer(customer);
            }
            else
            {
                customerService.EditCustomer(customer);
            }

            // Create shipping address
            
            shippingAddress.AddressId = 0;
            shippingAddress.FirstName = customer.FirstName;
            shippingAddress.LastName = customer.LastName;
            addressService.CreateAddress(shippingAddress);

            // Get cart
            cart = cartService.GetCartModel();

            // Create order
            var order = new Order
            {
                CustomerId = customer.CustomerId,
                ShipAddressId = shippingAddress.AddressId,
                PayPalOrderConfirmation = string.Empty,
                DateShipped = null,
                TotalAmount = cart.TotalPrice,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            orderService.CreateOrder(order);

            // Create order line items
            for (int i = 0; i < cart.Items.Count; i++)
            {
                var line = cart.Items[i];
                var orderItem = new OrderLineItem
                {
                    OrderId = order.OrderId,
                    OrderItemSequence = i + 1,
                    Configuration = line.Configuration,
                    ProductId = line.Product.ProductId,
                    Quantity = line.Quantity,
                    UnitPrice = line.UnitPrice
                };
                orderLineItemService.CreateOrderLineItem(orderItem);
            }

            return order.OrderId;
        }


        public int StoreOrderAndOrderItems(CartModel cart)
        {

            var order = new Order();
            var shippingAddress = new Address();
            var customer = new Customer();

            //order.OrderID
            //order.OrderDate = DateTime.Now;
            
            //order.ProductCount = cart.ComputeNumItems();
            
            

            customer.Email = string.Empty;
            
            shippingAddress.FirstName = string.Empty;
            shippingAddress.LastName = string.Empty;
            shippingAddress.AddressLine1 = string.Empty;
            shippingAddress.AddressLine2 = string.Empty;
            shippingAddress.AddressLine3 = string.Empty;
            shippingAddress.City = string.Empty;
            shippingAddress.Zip = string.Empty;
            shippingAddress.County = string.Empty;
            shippingAddress.Country = string.Empty;
            shippingAddress.Phone = string.Empty;
            
            //order.BillToAddressID = 1;
            //order.ShipToAddressID = 1;
            //order.CustomerID = 1;

            

            order.ShipAddressId = shippingAddress.AddressId;
            order.CustomerId = customer.CustomerId;

            _orderService.CreateOrder(order);

            

            return order.OrderId;
    }
}