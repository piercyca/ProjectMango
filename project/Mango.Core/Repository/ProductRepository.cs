using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Entities;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Product repository
    /// </summary>
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Product> GetProductsByPage(int currentPage, int noOfRecords, string sortBy)
        {
            var skip = noOfRecords * currentPage;
            var products = GetAll();
            products = products.Skip(skip).Take(noOfRecords);
            return products.ToList();
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// /// Method will return products as different page with specified number of records ,filter condition and sort criteria
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IEnumerable<Product> GetProductsByPage(int currentPage, int noOfRecords, string sortBy);
    }
}
