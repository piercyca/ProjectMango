using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Web.Areas.Admin.Models;

namespace Mango.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController() { }

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public virtual ActionResult List()
        {
            var productViewModel = new ProductCategoryListViewModel
            {
                ProductCategoryList = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryListItemViewModel>>(_productCategoryService.GetProductCategories())
            };
            return View(productViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var productCategory = _productCategoryService.GetProductCategory(id);
            var vm = Mapper.Map<ProductCategory, ProductCategoryFormViewModel>(productCategory);
            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Edit(ProductCategoryFormViewModel vm)
        {
            var productCategory = Mapper.Map<ProductCategoryFormViewModel, ProductCategory>(vm);
            if (ModelState.IsValid)
            {
                _productCategoryService.EditProductCategory(productCategory);
                return RedirectToAction(MVC.Admin.ProductCategory.List());
            }
            return View(vm);
        }

		[HttpGet]
		public virtual ActionResult Create()
		{
			var vm = Mapper.Map<ProductCategory, ProductCategoryFormViewModel>(new ProductCategory());
			return View(vm);
		}

		[HttpPost]
		public virtual ActionResult Create(ProductCategoryFormViewModel vm)
		{
			var productCategory = Mapper.Map<ProductCategoryFormViewModel, ProductCategory>(vm);
			if (ModelState.IsValid)
			{
				_productCategoryService.CreateProductCategory(productCategory);
				return RedirectToAction(MVC.Admin.ProductCategory.List());
			}
            return View(vm);
		}
    }
}