using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mango.Admin.Models;
using Mango.Admin.ViewModels;
using Mango.Core.Entity;
using Mango.Core.Repository;
using Mango.Core.Service;

namespace Mango.Admin.Controllers
{ 
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
    }
}