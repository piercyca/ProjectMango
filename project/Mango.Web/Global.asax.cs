using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mango.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsLocal)
            {
                var httpHost = Request.ServerVariables["HTTP_HOST"];
                var domainName = "etchieve.com";
                if (httpHost != domainName)
                {
                    Response.Redirect(string.Format("https://{0}{1}", domainName, HttpContext.Current.Request.RawUrl));
                }

                if (!HttpContext.Current.Request.IsSecureConnection)
                {
                    Response.Redirect(string.Format("https://{0}{1}", httpHost, HttpContext.Current.Request.RawUrl));
                }  
            }
        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
    }
}
