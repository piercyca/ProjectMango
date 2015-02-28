using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="OrderRepository"/>
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// Method will return products as different page with specified number of records , and sort criteria
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords);
    }


    /// <summary>
    /// Order repository
    /// </summary>
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="databaseFactory"></param>
        public OrderRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords)
        {
            var skip = noOfRecords * currentPage;
            var orders = GetAll();
            orders = orders.Skip(skip).Take(noOfRecords);
            return orders;
        }
    }
}
