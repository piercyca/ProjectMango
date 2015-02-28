using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords, string sortBy);
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

        public IEnumerable<Order> GetOrdersByPage(int currentPage, int noOfRecords, string sortBy)
        {
            var skip = noOfRecords * currentPage;
            var products = GetAll();
            products = products.Skip(skip).Take(noOfRecords);
            return products;
        }
    }
}
