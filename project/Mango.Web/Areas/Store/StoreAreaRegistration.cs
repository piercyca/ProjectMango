using System.Web.Http;
using System.Web.Mvc;

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

            // Web API configuration and services
            context.Routes.MapHttpRoute(
                name: "store_DefaultApi",
                routeTemplate: "store/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //context.MapRoute(
            //    "Store_default",
            //    "Store/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}