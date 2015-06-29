using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="ImageService"/> to access <see cref="Product"/> entities
    /// </summary>
    public interface IImageService
    {
        IEnumerable<string> GetImagePaths();
    }

    /// <summary>
    /// Service to access entities with image paths. New entities with image paths in Azure Storage 
    /// should be referenced here.
    /// </summary>
    public class ImageService : IImageService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageService _productImageService;
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationImageRepository _organizationImageRepository;
        private readonly IOrderLineItemRepository _orderLineItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="unitOfWork"></param>
        public ImageService(IProductRepository productRepository, IOrderLineItemRepository _orderLineItemRepository,  IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAll().OrderBy(p => p.Name);
        }
        
        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);
        }

        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public Product GetProduct(string urlSlug)
        {
            return _productRepository.Get(p => p.UrlSlug == urlSlug);
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="product"></param>
        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
            SaveProduct();
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="product"></param>
        public void EditProduct(Product product)
        {
            _productRepository.Update(product);
            SaveProduct();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product);
            SaveProduct();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveProduct()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Search product
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public IEnumerable<Product> SearchProductsByName(string productName)
        {
            return _productRepository.GetMany(p => p.Name.ToLower().Contains(productName.ToLower())).OrderBy(p => p.Name);
        }

        /// <summary>
        /// Get products by productCategoryId
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProductsByCategory(int productCategoryId)
        {
            return _productRepository.GetMany(p => p.ProductCategoryId == productCategoryId);
        }

        /// <summary>
        /// Get products by page
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProductsByPage(int currentPage, int noOfRecords, string sortBy)
        {
            return _productRepository.GetProductsByPage(currentPage, noOfRecords, sortBy);
        }

        /// <summary>
        /// Check if product category exists
        /// </summary>
        /// <param name="valueToCheck"></param>
        /// <param name="currentId"></param>
        /// <returns></returns>
        public bool UrlSlugExists(string valueToCheck, int currentId)
        {
            var pc = GetProduct(valueToCheck);
            if (pc != null)
            {
                if (currentId != pc.ProductId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
