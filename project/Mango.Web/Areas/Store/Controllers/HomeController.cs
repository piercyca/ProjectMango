using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Web.Areas.Store.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Store/Home
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}