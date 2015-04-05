using System.Collections.Generic;
using System.Linq;
using Mango.Core.Entity;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;

namespace Mango.Core.Service
{
    /// <summary>
    /// Interface to access a Service to access Product UrlSlugRedirect entities
    /// </summary>
    public interface IProductUrlSlugRedirectService
    {
        ProductUrlSlugRedirect GetProductUrlSlugRedirect(string oldUrlSlug);
        IEnumerable<ProductUrlSlugRedirect> GetProductUrlSlugRedirectNewUrlSlug(string newUrlSlug);
        void CreateProductUrlSlugRedirect(ProductUrlSlugRedirect productUrlSlugRedirect);
        void EditProductUrlSlugRedirect(ProductUrlSlugRedirect productUrlSlugRedirect);
        void DeleteProductUrlSlugRedirect(string oldUrlSlug);
        void SaveProductUrlSlugRedirect();
    }

    /// <summary>
    /// Service to access Product UrlSlugRedirect entities
    /// </summary>
    public class ProductUrlSlugRedirectService : IProductUrlSlugRedirectService
    {
        private readonly IProductUrlSlugRedirectRepository _productUrlSlugRedirectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductUrlSlugRedirectService(IProductUrlSlugRedirectRepository productUrlSlugRedirectRepository, IUnitOfWork unitOfWork)
        {
            _productUrlSlugRedirectRepository = productUrlSlugRedirectRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Returns a product urlSlugRedirect
        /// </summary>
        /// <param name="oldUrlSlug"></param>
        /// <returns></returns>
        public ProductUrlSlugRedirect GetProductUrlSlugRedirect(string oldUrlSlug)
        {
            return _productUrlSlugRedirectRepository.Get(pc => pc.OldUrlSlug == oldUrlSlug);
        }

        /// <summary>
        /// Returns productUrlSlugRedirects by newUrlSlug
        /// </summary>
        /// <param name="newUrlSlug"></param>
        /// <returns></returns>
        public IEnumerable<ProductUrlSlugRedirect> GetProductUrlSlugRedirectNewUrlSlug(string newUrlSlug)
        {
            return _productUrlSlugRedirectRepository.GetMany(pc => pc.NewUrlSlug == newUrlSlug);
        }

        /// <summary>
        /// Creates a product urlSlugRedirect
        /// </summary>
        /// <param name="productUrlSlugRedirect"></param>
        public void CreateProductUrlSlugRedirect(ProductUrlSlugRedirect productUrlSlugRedirect)
        {
            _productUrlSlugRedirectRepository.Add(productUrlSlugRedirect);
            SaveProductUrlSlugRedirect();
        }

        /// <summary>
        /// Edit a product urlSlugRedirect
        /// </summary>
        /// <param name="productUrlSlugRedirect"></param>
        public void EditProductUrlSlugRedirect(ProductUrlSlugRedirect productUrlSlugRedirect)
        {
            _productUrlSlugRedirectRepository.Update(productUrlSlugRedirect);
            SaveProductUrlSlugRedirect();
        }

        /// <summary>
        /// Delete a product urlSlugRedirect
        /// </summary>
        /// <param name="oldUrlSlug"></param>
        public void DeleteProductUrlSlugRedirect(string oldUrlSlug)
        {
            var productUrlSlugRedirect = _productUrlSlugRedirectRepository.GetById(oldUrlSlug);
            _productUrlSlugRedirectRepository.Delete(productUrlSlugRedirect);
            SaveProductUrlSlugRedirect();
        }

        /// <summary>
        /// Commit to persistence layer
        /// </summary>
        public void SaveProductUrlSlugRedirect()
        {
            _unitOfWork.Commit();
        }
    }
}
