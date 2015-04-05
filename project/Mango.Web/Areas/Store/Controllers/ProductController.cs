using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Web.Areas.Store.Models;

namespace Mango.Web.Areas.Store.Controllers
{
    [RoutePrefix("product")]
    public partial class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductImageService _productImageService;

        //public ProductController() { }

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IProductImageService productImageService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productImageService = productImageService;
        }

        /// <summary>
        /// GET: /store/product/
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// GET: /store/product/customize/{urlSlug}
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Customize(string urlSlug)
        {
            return View();
        }

        /// <summary>
        /// GET: /store/product/detail/{urlSlug}
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        [Route("detail/{urlslug}")]
        [HttpGet]
        public virtual ActionResult Detail(string urlSlug)
        {
            var product = _productService.GetProduct(urlSlug);
            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<Product, ProductDetailViewModel>(product);

            var productImages = _productImageService.GetProductImages(viewModel.ProductId);
            viewModel.ProductImages = Mapper.Map<List<ProductImage>, List<ProductImageViewModel>>(productImages.ToList());

            return View(viewModel);
        }

    }
}