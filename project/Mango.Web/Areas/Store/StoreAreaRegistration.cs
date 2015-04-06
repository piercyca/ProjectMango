using System.Web.Mvc;
using RouteMagic;

namespace Mango.Web.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var routes = context.Routes;

            routes.LowercaseUrls = true;

            //context.MapRoute(
            //    "Store_default",
            //    "Store/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}