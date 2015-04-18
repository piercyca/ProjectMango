using System;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Service;


namespace Mango.Core.Web.Checkout
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICheckoutService
    {
        Customer Customer(string loggedInUsername, bool isAuthenticated);
        Address ShippingAddress(Customer customer);
        int CreateOrder(Customer customer, Address shippingAddress);
    }

    /// <summary>
    /// 
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
                customer = _customerService.GetCustomer(loggedInUsername) ??
                           new Customer {Email = loggedInUsername, Username = loggedInUsername};
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
                FirstName = customer.FirstName,
                LastName = customer.LastName
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
            Console.WriteLine("CheckoutService - {0} - {1}", customer.CustomerId, shippingAddress.AddressId);

            // Check if cart is empty
            var cart = _cartService.GetCartModel();
            if (!cart.Items.Any())
            {
                //todo capture error
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
            shippingAddress.FirstName = customer.FirstName;
            shippingAddress.LastName = customer.LastName;
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
                    UnitPrice = line.UnitPrice
                };
                _orderLineItemService.CreateOrderLineItem(orderItem);
            }

            return order.OrderId;
        }


        //    public int StoreOrderAndOrderItems(CartModel cart)
        //    {

        //        var order = new Order();
        //        var shippingAddress = new Address();
        //        var customer = new Customer();

        //        //order.OrderID
        //        //order.OrderDate = DateTime.Now;

        //        //order.ProductCount = cart.ComputeNumItems();



        //        customer.Email = string.Empty;

        //        shippingAddress.FirstName = string.Empty;
        //        shippingAddress.LastName = string.Empty;
        //        shippingAddress.AddressLine1 = string.Empty;
        //        shippingAddress.AddressLine2 = string.Empty;
        //        shippingAddress.AddressLine3 = string.Empty;
        //        shippingAddress.City = string.Empty;
        //        shippingAddress.Zip = string.Empty;
        //        shippingAddress.County = string.Empty;
        //        shippingAddress.Country = string.Empty;
        //        shippingAddress.Phone = string.Empty;

        //        //order.BillToAddressID = 1;
        //        //order.ShipToAddressID = 1;
        //        //order.CustomerID = 1;



        //        order.ShipAddressId = shippingAddress.AddressId;
        //        order.CustomerId = customer.CustomerId;

        //        //_orderService.CreateOrder(order);



        //        return order.OrderId;
        //}
    }
}