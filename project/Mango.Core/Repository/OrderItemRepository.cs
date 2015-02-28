using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="OrderLineItemRepository"/>
    /// </summary>
    public interface IOrderLineItemRepository : IRepository<OrderLineItem>
    {
        /// <summary>
        /// Method will return order items based on orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        IEnumerable<OrderLineItem> GetOrderLineItemsByOrder(int orderId);
    }


    /// <summary>
    /// OrderLineItem repository
    /// </summary>
    public class OrderLineItemRepository : RepositoryBase<OrderLineItem>, IOrderLineItemRepository
    {
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="databaseFactory"></param>
        public OrderLineItemRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<OrderLineItem> GetOrderLineItemsByOrder(int orderId)
        {
            return GetAll().Where(i => i.OrderId == orderId).OrderBy(i => i.OrderItemSequence);
        }
    }
}
