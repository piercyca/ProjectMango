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
    /// Interface for <see cref="CustomerRepository"/>
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Method will return products as different page with specified number of records , and sort criteria
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IEnumerable<Customer> GetCustomersByPage(int currentPage, int noOfRecords, string sortBy);
    }


    /// <summary>
    /// Customer repository
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="databaseFactory"></param>
        public CustomerRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Customer> GetCustomersByPage(int currentPage, int noOfRecords, string sortBy)
        {
            var skip = noOfRecords * currentPage;
            var products = GetAll();
            products = products.Skip(skip).Take(noOfRecords);
            return products;
        }
    }
}
