using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="OrderService"/> to access <see cref="Order"/> entities
    /// </summary>
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        void CreateOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(int id);
        void SaveOrder();   
        IEnumerable<Order> GetOrdersByCustomer(int customerId);
        IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords, string sortBy);
        void UpdatePayPalProperties(int orderId, string payPalToken, string payPalPayerId, string payPalEmail, string payPalOrderConfirmation);
    }

    /// <summary>
    /// Service to access <see cref="Order"/> entities
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="unitOfWork"></param>
        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        /// <summary>
        /// Returns a order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrder(int id)
        {
            return _orderRepository.GetById(id);
        }

        /// <summary>
        /// Creates a order
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
            SaveOrder();
        }

        /// <summary>
        /// Edit a order
        /// </summary>
        /// <param name="order"></param>
        public void EditOrder(Order order)
        {
            _orderRepository.Update(order);
            SaveOrder();
        }

        /// <summary>
        /// Delete a order
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            _orderRepository.Delete(order);
            SaveOrder();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveOrder()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Gets order(s) for customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrdersByCustomer(int customerId)
        {
            return _orderRepository.GetMany(o => o.CustomerId == customerId);
        }

        /// <summary>
        /// Get orders by page
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords, string sortBy)
        {
            return _orderRepository.GetOrdersByPage(currentPage, noOfRecords);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payPalToken"></param>
        /// <param name="payPalPayerId"></param>
        /// <param name="payPalEmail"></param>
        /// <param name="payPalNote"></param>
        /// <param name="payPalOrderConfirmation"></param>
        public void UpdatePayPalProperties(int orderId, string payPalToken, string payPalPayerId, string payPalEmail, string payPalOrderConfirmation)
        {
            var order = _orderRepository.GetById(orderId);
            order.PayPalToken = payPalToken;
            order.PayPalPayerId = payPalPayerId;
            order.PayPalOrderConfirmation = payPalOrderConfirmation;
            order.PayPalEmail = payPalEmail;
            _orderRepository.Update(order);
            SaveOrder();
        }


        public int UpdateOrderConfirmation(int id, string payPalPaymentConfirmation)
        {
            var order = _orderRepository.GetById(id);
            order.PayPalOrderConfirmation = payPalPaymentConfirmation;
            _orderRepository.Update(order);
            SaveOrder();
            return order.OrderId;
        }
    }
}
