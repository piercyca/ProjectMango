using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a Service to access Customer entities
    /// </summary>
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        void CreateOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(int id);
        void SaveOrder();
        IEnumerable<Order> SearchOrderCustomerId(int customerId);
        IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords, string sortBy);
    }

    /// <summary>
    /// Service to access Order entities
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
            return _orderRepository.GetAll().OrderBy(p => p.LastName);
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
        /// Search order by custom name. Checks first name and last name.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IEnumerable<Order> SearchOrderCustomerId(int customerId)
        {
            return _orderRepository.GetMany(o => o.CustomerId == customerId));
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
            return _orderRepository.GetOrdersByPage(currentPage, noOfRecords, sortBy);
        }
    }
}
