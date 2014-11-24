using System.Web.Mvc;

namespace Mango.Web.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}