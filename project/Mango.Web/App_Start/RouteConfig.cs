using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Mango.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.RouteExistingFiles = true;

            // Map Controller Attribute Route Contraints
            var constraintsResolver = new DefaultInlineConstraintResolver();
            routes.MapMvcAttributeRoutes(constraintsResolver);
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("BlobImage",
                "bi/{container}/{*blobid}",
                new { controller = "Utility", action = "BlobImage", container = "", blobid = "" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] {"Mango.Web.Controllers"}
            );
        }
    }
}
