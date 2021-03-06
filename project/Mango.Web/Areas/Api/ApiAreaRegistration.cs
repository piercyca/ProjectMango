﻿using System.Web.Http;
using System.Web.Mvc;

namespace Mango.Web.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Lowercase Urls
            context.Routes.LowercaseUrls = true;

            // Web API configuration and services
            context.Routes.MapHttpRoute(
                name: "api_DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}