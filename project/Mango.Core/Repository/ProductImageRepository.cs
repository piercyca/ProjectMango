using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;

namespace Mango.Core.Repository
{
    /// <summary>
    /// Interface for <see cref="ProductImageRepository"/>
    /// </summary>
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        /// <summary>
        /// Method will return product images for a product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        IEnumerable<ProductImage> GetProductImages(int productId);

        /// <summary>
        /// Gets a product image
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        ProductImage GetProductImage(int productId, int sortOrder);
    }

    /// <summary>
    /// Product Image repository
    /// </summary>
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseFactory"></param>
        public ProductImageRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        /// <summary>
        /// Gets the product images for a product and sorts by SortOrder
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IEnumerable<ProductImage> GetProductImages(int productId)
        {
            return GetAll().Where(pi => pi.ProductId == productId).OrderBy(pi => pi.SortOrder);
        }

        /// <summary>
        /// Gets a product image
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public ProductImage GetProductImage(int productId, int sortOrder)
        {
            return Get(pi => pi.ProductId == productId && pi.SortOrder == sortOrder);
        }
    }
}
