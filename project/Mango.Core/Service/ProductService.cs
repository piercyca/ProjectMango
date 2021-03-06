﻿using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a <see cref="ProductService"/> to access <see cref="Product"/> entities
    /// </summary>
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string urlSlug);
        void CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int id);
        void SaveProduct();
        IEnumerable<Product> SearchProductsByName(string productName);
        IEnumerable<Product> GetProductsByCategory(int productCategoryId);
        IEnumerable<Product> GetProductsByPage(int currentPage, int noOfRecords, string sortBy);
    }

    /// <summary>
    /// Service to access <see cref="Product"/> entities
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="unitOfWork"></param>
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
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
