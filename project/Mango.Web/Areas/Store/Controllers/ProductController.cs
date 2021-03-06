﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Web.Areas.Store.Models;
using Mango.Web.Attributes;

namespace Mango.Web.Areas.Store.Controllers
{
    [RouteArea("store")]
    [RoutePrefix("product")]
    [Route("{action}")]
    [LogoutIfAdmin]
    public partial class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductImageService _productImageService;

        public ProductController() { }

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
            var productCategory = _productCategoryService.GetProductCategoriesWithProducts().OrderBy(pc => pc.Name).ToList()[0];
            return RedirectToAction(MVC.StoreArea.Product.Category(productCategory.UrlSlug));
        }

        /// <summary>
        /// GET: /store/product/category/{urlSlug}
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("category/{urlSlug:regex([a-z0-9-_]*)}")]
        public virtual ActionResult Category(string urlSlug)
        {
            var productCategory = _productCategoryService.GetProductCategory(urlSlug);
            if (productCategory == null)
            {
                return HttpNotFound();
            }

            var productCategories = _productCategoryService.GetProductCategoriesWithProducts().ToList();
            var viewModel = new ProductCategoryViewModel()
            {
                Categories = Mapper.Map<List<ProductCategory>, List<ProductCategoryDetailViewModel>>(productCategories),
                Products = Mapper.Map<List<Product>, List<ProductDetailViewModel>>(productCategory.Products.Where(p => !p.Archived && !string.IsNullOrEmpty(p.CanvasImage)).ToList()),
                SelectedCategory = Mapper.Map<ProductCategory, ProductCategoryDetailViewModel>(productCategory)
            };

            foreach (var product in viewModel.Products)
            {
                var productImages = _productImageService.GetProductImages(product.ProductId);
                product.ProductImages = Mapper.Map<List<ProductImage>, List<ProductImageViewModel>>(productImages.ToList());
            }

            return View(viewModel);
        }


        /// <summary>
        /// GET: /store/product/customize/{urlSlug}
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        [Route("customize/{urlSlug:regex([a-z0-9-_]*)}")]
        [HttpGet]
        public virtual ActionResult Customize(string urlSlug)
        {
            var product = _productService.GetProduct(urlSlug);
            if (product == null)
            {
                return HttpNotFound();
            }
            if (product.Archived || string.IsNullOrEmpty(product.CanvasImage))
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