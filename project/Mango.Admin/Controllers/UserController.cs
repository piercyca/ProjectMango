using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Admin.Models;
using Mango.Core.Data;

namespace Mango.Admin.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var app = new ApplicationDbContext();
            var users = app.Users.Select(s => s);
            var context = new Mango.Core.Data.MangoContext();
            //var products = context.Products.Select(s => s);
            //var users = context.
            return View(users);
        }

       
    }
}