using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Web.Areas.Store.Controllers
{
    public partial class ProductController : Controller
    {
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

    }
}