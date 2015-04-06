using System.Web.Mvc;

namespace Mango.Web.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var routes = context.Routes;

            routes.LowercaseUrls = true;

            var routeStoreHomeRedirect = routes.MapRoute("StoreHomeRedirectTo",
                "store/{controller}/{action}",
                new { area = "store", controller = "home", action = "index" },
                namespaces: new[] { "Mango.Web.Areas.Store.Controllers" });
            routes.Redirect
            //routes.Redirect(r => r.MapRoute("StoreHomeRedirect", "store")).To(routeStoreHomeRedirect);

            //context.MapRoute(
            //    "Store_default",
            //    "Store/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}