using System.Web.Http;
using System.Web.Mvc;

namespace Mango.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;

            // Web API configuration and services
            context.Routes.MapHttpRoute(
                name: "admin_DefaultApi",
                routeTemplate: "admin/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Routes
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Mango.Web.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "admin_wildcard",
                url: "admin/",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "Mango.Web.Areas.Admin.Controllers" }
            );
        }
    }
}