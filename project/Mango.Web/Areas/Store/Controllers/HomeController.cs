using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Web.Attributes;

namespace Mango.Web.Areas.Store.Controllers
{
    [RouteArea("store")]
    [RoutePrefix("home")]
    [Route("{action=index}")]
    [LogoutIfAdmin]
    public partial class HomeController : Controller
    {
        // GET: Store/Home
        public virtual ActionResult Index()
        {
            // Redirects when the path is /store/home/index or /store/home/index/. #SEO
            var url = Request.Url;
            if (url != null && (url.ToString().EndsWith("index") || url.ToString().EndsWith("index/")))
            {
                return RedirectToActionPermanent(MVC.StoreArea.Home.Index());
            }

            return View();
        }
    }
}