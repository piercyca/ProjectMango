using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Common;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int id);
        void SaveProduct();
        IEnumerable<Product> SearchProduct(string productName);

        IEnumerable<Product> GetProductsByPage(int currentPage, int noOfRecords, string sortBy);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

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
        public IEnumerable<Product> SearchProduct(string productName)
        {
            return _productRepository.GetMany(p => p.Name.ToLower().Contains(productName.ToLower())).OrderBy(p => p.Name);
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
    }
}
