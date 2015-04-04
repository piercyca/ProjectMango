using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Core.Web.Extensions;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        /// GET: /product/
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return RedirectToActionPermanent(MVC.Admin.Product.List());
        }

        /// <summary>
        /// GET: /products/list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult List() //TODO (later) paginate .... string sortBy = "Date", int page = 0
        {
            var products = _productService.GetProducts();
            var productViewModel = new ProductListViewModel
            {
                ProductList = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductListItemViewModel>>(products)
            };
            return View(productViewModel);
        }

        /// <summary>
        /// GET: /products/create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Create()
        {
            var viewModel = new ProductFormViewModel();

            var productCategories = _productCategoryService.GetProductCategories().ToList();
            viewModel.ProductCategories = productCategories.ToSelectListItems(productCategories[0].ProductCategoryId);

            return View(viewModel);
        }

        /// <summary>
        /// POST: /products/create/
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Create(ProductFormViewModel viewModel)
        {
            var product = Mapper.Map<ProductFormViewModel, Product>(viewModel);
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                _productImageService.InsertProductImages(product.ProductId, viewModel.ProductImagesString);
                return RedirectToAction(MVC.Admin.Product.List());
            }
            var productCategories = _productCategoryService.GetProductCategories();
            viewModel.ProductCategories = productCategories.ToSelectListItems(product.ProductCategoryId);
            return View(viewModel);
        }

        /// <summary>
        /// GET: /products/edit/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var product = _productService.GetProduct(id);
            var viewModel = Mapper.Map<Product, ProductFormViewModel>(product);

            var productCategories = _productCategoryService.GetProductCategories();
            viewModel.ProductCategories = productCategories.ToSelectListItems(product.ProductCategoryId);

            var productImages = _productImageService.GetProductImages(id);
            viewModel.ProductImages = Mapper.Map<IEnumerable<ProductImage>, IEnumerable<ProductImageFormViewModel>>(productImages);

            return View(viewModel);
        }


        /// <summary>
        /// POST: /products/edit/
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Edit(ProductFormViewModel viewModel)
        {
            var product = Mapper.Map<ProductFormViewModel, Product>(viewModel);
            if (ModelState.IsValid)
            {
                _productService.EditProduct(product);
                _productImageService.InsertProductImages(viewModel.ProductId, viewModel.ProductImagesString);
                return RedirectToAction(MVC.Admin.Product.List());
            }
            var productCategories = _productCategoryService.GetProductCategories();
            viewModel.ProductCategories = productCategories.ToSelectListItems(product.ProductCategoryId);
            return View(viewModel);
        }

        /// <summary>
        /// GET: /product/fileupload
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult FileUpload()
        {
            return View();
        }

        /// <summary>
        /// GET: /product/layout/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Layout(int id)
        {
            var product = _productService.GetProduct(id);
            var viewModel = Mapper.Map<Product, ProductLayoutFormViewModel>(product);
            return View(viewModel);
        }

        /// <summary>
        /// POST: /products/layout/{id}
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Layout(ProductLayoutFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetProduct(viewModel.ProductId);
                var productLayout = Mapper.Map<ProductLayoutFormViewModel, Product>(viewModel, product);
                _productService.EditProduct(product);
                return RedirectToAction(MVC.Admin.Product.List());
            }
            return View(viewModel);
        }
    }
}