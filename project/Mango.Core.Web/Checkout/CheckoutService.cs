using System;
using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Service;


namespace Mango.Core.Web.Checkout
{
    /// <summary>
    /// Checkout Service Interface
    /// </summary>
    public interface ICheckoutService
    {
        Customer Customer(string loggedInUsername, bool isAuthenticated);
        Address ShippingAddress(Customer customer);
        int CreateOrder(Customer customer, Address shippingAddress);
        void UpdateShippingAddress(int orderId, string fullName, string addressLine1,
            string addressLine2, string city, string zip, string state);
    }

    /// <summary>
    /// Checkout Service
    /// </summary>
    public class CheckoutService : ICheckoutService
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IOrderLineItemService _orderLineItemService;
        private readonly ICartService _cartService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressService"></param>
        /// <param name="customerService"></param>
        /// <param name="orderService"></param>
        /// <param name="orderLineItemService"></param>
        /// <param name="cartService"></param>
        public CheckoutService(IAddressService addressService, ICustomerService customerService,
            IOrderService orderService, IOrderLineItemService orderLineItemService, ICartService cartService)
        {
            _addressService = addressService;
            _customerService = customerService;
            _orderService = orderService;
            _orderLineItemService = orderLineItemService;
            _cartService = cartService;
        }

        /// <summary>
        /// Setup customer
        /// </summary>
        /// <param name="loggedInUsername"></param>
        /// <param name="isAuthenticated"></param>
        /// <returns></returns>
        public Customer Customer(string loggedInUsername, bool isAuthenticated)
        {
            var customer = new Customer();
            if (isAuthenticated && (!string.IsNullOrEmpty(loggedInUsername)))
            {
                customer = _customerService.GetCustomer(loggedInUsername) ?? new Customer {Email = loggedInUsername, Username = loggedInUsername};
            }
            return customer;
        }

        /// <summary>
        /// Setups shipping address for an order
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Address ShippingAddress(Customer customer)
        {
            // Setup default addresses
            var address = new Address
            {
                AddressType = AddressType.Ship,
                Status = AddressStatus.Active,
                Country = "US",
                FullName = customer.FullName
            };

            // Get last order addresses
            if (customer.CustomerId > 0)
            {
                var order =
                    _orderService.GetOrdersByCustomer(customer.CustomerId)
                        .OrderByDescending(o => o.DateCreated)
                        .FirstOrDefault();
                if (order != null)
                {
                    if (order.ShipAddress != null)
                    {
                        address = order.ShipAddress;
                    }
                }
            }
            return address;
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="shippingAddress"></param>
        /// <returns>OrderId</returns>
        public int CreateOrder(Customer customer, Address shippingAddress)
        {
            // Check if cart is empty
            var cart = _cartService.GetCartModel();
            if (!cart.Items.Any())
            {
                ExceptionLogger.Log("Order created without cart items.", new List<object>{customer, shippingAddress});
                return 0;
            }

            // Create or Edit customer
            if (customer.CustomerId == 0)
            {
                _customerService.CreateCustomer(customer);
            }
            else
            {
                _customerService.EditCustomer(customer);
            }

            // Create shipping address
            shippingAddress.AddressId = 0;
            shippingAddress.FullName = customer.FullName;
            _addressService.CreateAddress(shippingAddress);

            // Get cart
            cart = _cartService.GetCartModel();

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
            _orderService.CreateOrder(order);

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
                    UnitPrice = line.UnitPrice,
                    OrderImage = line.OrderImage
                };
                _orderLineItemService.CreateOrderLineItem(orderItem);
            }

            return order.OrderId;
        }

        /// <summary>
        /// Update Shipping Address from PayPal
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="fullName"></param>
        /// <param name="addressLine1"></param>
        /// <param name="addressLine2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        public void UpdateShippingAddress(int orderId, string fullName, string addressLine1, string addressLine2,
            string city, string state, string zip)
        {
            var shippingAddress = _orderService.GetOrder(orderId).ShipAddress;
            shippingAddress.FullName = fullName;
            shippingAddress.AddressLine1 = addressLine1;
            shippingAddress.AddressLine2 = addressLine2;
            shippingAddress.City = city;
            shippingAddress.State = state;
            shippingAddress.Zip = zip;
            _addressService.EditAddress(shippingAddress);

        }
    }
}