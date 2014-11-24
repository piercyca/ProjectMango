using System.Web.Mvc;

namespace Mango.Admin.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}