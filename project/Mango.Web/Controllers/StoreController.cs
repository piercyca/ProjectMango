using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Exists only for redirects. See the "area" named "store" for the store functionality.
    /// </summary>
    public partial class StoreController : Controller
    {
        // GET: Store
        public virtual ActionResult Index()
        {
            return RedirectToActionPermanent(MVC.StoreArea.Home.Index());
        }
    }
}