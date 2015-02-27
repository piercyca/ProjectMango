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
    /// Product Category repository
    /// </summary>
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<ProductCategory> GetProductCategories(string sortBy)
        {
            var productCategories = GetAll();
            return productCategories;
        }
    }

    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        /// <summary>
        /// Method will return product categories with sort criteria
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IEnumerable<ProductCategory> GetProductCategories(string sortBy);
    }
}
