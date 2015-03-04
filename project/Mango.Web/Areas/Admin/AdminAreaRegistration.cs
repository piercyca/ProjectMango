using System.Web.Mvc;

namespace Mango.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Mango.Web.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Admin_wildcard",
                url: "Admin/",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "Mango.Web.Areas.Admin.Controllers" }
            );
        }
    }
}