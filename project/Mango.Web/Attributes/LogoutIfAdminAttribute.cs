using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;

namespace Mango.Web.Attributes
{
    public class LogoutIfAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //if (HttpContext.Current.User.Identity.IsAuthenticated && 
            //    !HttpContext.Current.User.IsInRole("Customer"))
            //{
            //    HttpContext.Current.GetOwinContext().Authentication.SignOut();
            //}
            base.OnActionExecuting(actionContext);
        }
    }
}