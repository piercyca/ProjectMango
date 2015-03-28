using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a Service to access Product Category entities
    /// </summary>
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        ProductCategory GetProductCategory(string urlSlug);
        void CreateProductCategory(ProductCategory productCategory);
        void EditProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(int id);
        void SaveProductCategory();
        IEnumerable<ProductCategory> SearchProductCategory(string productCategoryName);
        bool UrlSlugExists(string valueToCheck, int currentId);
    }

    /// <summary>
    /// Service to access Product Category entities
    /// </summary>
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return _productCategoryRepository.GetAll().OrderBy(pc => pc.Name);
        }

        /// <summary>
        /// Returns a product category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductCategory GetProductCategory(int id)
        {
            return _productCategoryRepository.GetById(id);
        }

        public ProductCategory GetProductCategory(string urlSlug)
        {
            return _productCategoryRepository.Get(pc => pc.UrlSlug == urlSlug);
        }

        /// <summary>
        /// Creates a product category
        /// </summary>
        /// <param name="productCategory"></param>
        public void CreateProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.Add(productCategory);
            SaveProductCategory();
        }

        /// <summary>
        /// Edit a product category
        /// </summary>
        /// <param name="productCategory"></param>
        public void EditProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
            SaveProductCategory();
        }

        /// <summary>
        /// Delete a product category
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProductCategory(int id)
        {
            var productCategory = _productCategoryRepository.GetById(id);
            _productCategoryRepository.Delete(productCategory);
            SaveProductCategory();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveProductCategory()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Search product category
        /// </summary>
        /// <param name="productCategoryName"></param>
        /// <returns></returns>
        public IEnumerable<ProductCategory> SearchProductCategory(string productCategoryName)
        {
            return _productCategoryRepository.GetMany(p => p.Name.ToLower().Contains(productCategoryName.ToLower())).OrderBy(p => p.Name);
        }

        /// <summary>
        /// Check if product category exists
        /// </summary>
        /// <param name="valueToCheck"></param>
        /// <param name="currentId"></param>
        /// <returns></returns>
        public bool UrlSlugExists(string valueToCheck, int currentId)
        {
            var pc = GetProductCategory(valueToCheck);
            if (pc != null)
            {
                if (currentId != pc.ProductCategoryId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
