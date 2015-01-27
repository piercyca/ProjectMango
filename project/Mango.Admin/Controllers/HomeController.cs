using System.Web.Mvc;
using System.Web.Security;

namespace Mango.Admin.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}