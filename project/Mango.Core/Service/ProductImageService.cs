using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;
using Newtonsoft.Json;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="ProductImageService"/> to access <see cref="ProductImage"/> entities
    /// </summary>
    public interface IProductImageService
    {
        ProductImage GetProductImage(int productId, int sortOrder);
        void DeleteProductImages(int productId);
        void InsertProductImages(int productId, string urls);
        IEnumerable<ProductImage> GetProductImages(int productId);
    }

    /// <summary>
    /// Service to access <see cref="ProductImage"/> entities
    /// </summary>
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productImageRepository"></param>
        /// <param name="unitOfWork"></param>
        public ProductImageService(IProductImageRepository productImageRepository, IUnitOfWork unitOfWork)
        {
            _productImageRepository = productImageRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveProductImage()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Get a Product Image
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public ProductImage GetProductImage(int productId, int sortOrder)
        {
            return _productImageRepository.GetProductImage(productId, sortOrder);
        }

        /// <summary>
        /// Deletes Product Images
        /// </summary>
        /// <param name="productId"></param>
        public void DeleteProductImages(int productId)
        {
            var productImages = _productImageRepository.GetProductImages(productId);
            foreach (var productImage in productImages)
            {
                _productImageRepository.Delete(productImage);
            }
            SaveProductImage();
        }

        /// <summary>
        /// Inserts product image(s)
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="urls"></param>
        public void InsertProductImages(int productId, string urls)
        {
            // delete first, prevents sort conflicts from existing data
            DeleteProductImages(productId);
            // save the updated records
            var urlList = JsonConvert.DeserializeObject<object[]>(urls);
            for (int i = 0; i < urlList.Length; i++)
            {
                _productImageRepository.Add(new ProductImage
                {
                    ProductId = productId,
                    Url = urlList[i].ToString(),
                    SortOrder = i
                });
            }
            // Save changes
            SaveProductImage();
        }

        public IEnumerable<ProductImage> GetProductImages(int productId)
        {
            return _productImageRepository.GetProductImages(productId);
        }
    }
}
