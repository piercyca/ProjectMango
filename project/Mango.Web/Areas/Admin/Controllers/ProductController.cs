using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Core.Web.Extensions;
using Mango.Web.ViewModels;

namespace Mango.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController() { }

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        // GET: Product
        public virtual ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: /products/list
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult List(string sortBy = "Date", int page = 0)
        {
            var products = _productService.GetProductsByPage(page, 20, sortBy);
            var productViewModel = new ProductListViewModel
            {
                ProductList = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductListItemViewModel>>(products)
            };
            return View(productViewModel);
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
            return View(viewModel);
        }

        /// <summary>
        /// POST: /products/edit/
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual ActionResult Edit(ProductFormViewModel viewModel)
        {
            var product = Mapper.Map<ProductFormViewModel, Product>(viewModel);
            if (ModelState.IsValid)
            {
                _productService.EditProduct(product);
                return RedirectToAction("List");
            }
            var productCategories = _productCategoryService.GetProductCategories();
            viewModel.ProductCategories = productCategories.ToSelectListItems(product.ProductCategoryId);
            return View(viewModel);
        }
    }
}