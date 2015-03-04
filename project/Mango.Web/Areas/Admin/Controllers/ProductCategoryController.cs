using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Entity;
using Mango.Core.Service;
using Mango.Web.ViewModels;

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
        public virtual ActionResult Index()
        {
            var productCategories = _productCategoryService.GetProductCategories();
            return View(productCategories);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var productCategory = _productCategoryService.GetProductCategory(id);
            var vm = Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategory);
            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Edit(ProductCategoryViewModel vm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(vm);
            if (ModelState.IsValid)
            {
                _productCategoryService.EditProductCategory(productCategory);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

		[HttpGet]
		public virtual ActionResult Create()
		{
			var vm = Mapper.Map<ProductCategory, ProductCategoryViewModel>(new ProductCategory());
			return View(vm);
		}

		[HttpPost]
		public virtual ActionResult Create(ProductCategoryViewModel vm)
		{
			var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(vm);
			if (ModelState.IsValid)
			{
				_productCategoryService.CreateProductCategory(productCategory);
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
    }
}