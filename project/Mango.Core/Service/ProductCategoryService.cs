using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entities;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        void CreateProductCategory(ProductCategory productCategory);
        void EditProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(int id);
        void SaveProductCategory();
        IEnumerable<ProductCategory> SearchProductCategory(string productCategoryName);
    }

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
            return _productCategoryRepository.GetAll().OrderBy(p => p.Name);
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
    }
}
