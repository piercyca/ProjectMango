using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Web.Areas.Store.Controllers
{
    [RouteArea("store")]
    [RoutePrefix("cart")]
    [Route("{action}")]
    public partial class CartController : Controller
    {
        /// <summary>
        /// GET: /store/cart
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}