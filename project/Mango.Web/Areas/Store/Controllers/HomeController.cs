using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mango.Core.Service;
using Mango.Web.Areas.Store.Models;
using Mango.Web.Attributes;
using Mango.Core.Entity;

namespace Mango.Web.Areas.Store.Controllers
{
    [RouteArea("store")]
    [RoutePrefix("home")]
    [Route("{action=index}")]
    [LogoutIfAdmin]
    public partial class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController() { }

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Store/Home
        public virtual ActionResult Index()
        {
            // Redirects when the path is /store/home/index or /store/home/index/. #SEO
            var url = Request.Url;
            if (url != null && (url.ToString().EndsWith("index") || url.ToString().EndsWith("index/")))
            {
                return RedirectToActionPermanent(MVC.StoreArea.Home.Index());
            }

            var viewModel = new HomeIndexViewModel
            {
                Products = Mapper.Map<List<Product>, List<ProductDetailViewModel>>(_productService.GetProducts().Where(p => !p.Archived).Take(8).ToList())
            };

            return View(viewModel);
        }
    }
}