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
    /// Interface for <see cref="ProductCategoryRepository"/>
    /// </summary>
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        /// <summary>
        /// Method will return product categories with sort criteria
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductCategory> GetProductCategories();
    }

    /// <summary>
    /// Product Category repository
    /// </summary>
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            var productCategories = GetAll();
            return productCategories;
        }
    }
}
