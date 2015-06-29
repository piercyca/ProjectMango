using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="OrderLineItemService"/> to access <see cref="OrderLineItem"/> entities
    /// </summary>
    public interface IOrderLineItemService
    {
        IEnumerable<OrderLineItem> GetOrderLineItems();
        OrderLineItem GetOrderLineItem(int id);
        void CreateOrderLineItem(OrderLineItem order);
        void EditOrderLineItem(OrderLineItem order);
        void DeleteOrderLineItem(int id);
        void SaveOrderLineItem();
        IEnumerable<OrderLineItem> GetOrderLineItemsByOrder(int orderId);
    }

    /// <summary>
    /// Service to access <see cref="OrderLineItem"/> entities
    /// </summary>
    public class OrderLineItemService : IOrderLineItemService
    {
        private readonly IOrderLineItemRepository _orderLineItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderLineItemRepository"></param>
        /// <param name="unitOfWork"></param>
        public OrderLineItemService(IOrderLineItemRepository orderLineItemRepository, IUnitOfWork unitOfWork)
        {
            _orderLineItemRepository = orderLineItemRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderLineItem> GetOrderLineItems()
        {
            return _orderLineItemRepository.GetAll().OrderBy(o => o.OrderItemSequence);
        }

        /// <summary>
        /// Returns a order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderLineItem GetOrderLineItem(int id)
        {
            return _orderLineItemRepository.GetById(id);
        }

        /// <summary>
        /// Creates a order
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrderLineItem(OrderLineItem order)
        {
            _orderLineItemRepository.Add(order);
            SaveOrderLineItem();
        }

        /// <summary>
        /// Edit a order
        /// </summary>
        /// <param name="order"></param>
        public void EditOrderLineItem(OrderLineItem order)
        {
            _orderLineItemRepository.Update(order);
            SaveOrderLineItem();
        }

        /// <summary>
        /// Delete a order
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrderLineItem(int id)
        {
            var order = _orderLineItemRepository.GetById(id);
            _orderLineItemRepository.Delete(order);
            SaveOrderLineItem();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveOrderLineItem()
        {
            _unitOfWork.Commit();
        }

        
        /// <summary>
        /// Get orders line item for order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public IEnumerable<OrderLineItem> GetOrderLineItemsByOrder(int orderId)
        {
            return _orderLineItemRepository.GetOrderLineItemsByOrder(orderId);
        }
    }
}
