using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="ProductRepository"/>
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Method will return products as different page with specified number of records ,filter condition and sort criteria
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IEnumerable<Product> GetProductsByPage(int currentPage, int noOfRecords, string sortBy);
    }

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
            
            // sort records
            products = (sortBy == "Name") ? products.OrderBy(p => p.Name) : products;
            products = (sortBy == "UrlSlug") ? products.OrderBy(p => p.UrlSlug) : products;
            
            return products;
        }
    }
}
