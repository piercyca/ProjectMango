using System.Web.Mvc;

namespace Mango.Admin.Controllers {
    public class ErrorController : Controller {
        public ActionResult Http404() {
            Response.StatusCode = 404;

            return View();
        }
    }
}