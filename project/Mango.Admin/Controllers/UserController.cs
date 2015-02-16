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
            var db = new ApplicationDbContext();
            var users = db.Users.Select(s => s);
            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(string id, string username, string email, string phone)
        {
            var db = new ApplicationDbContext();
            var user = db.Users.Find(id);
            if (TryUpdateModel(user))
            {
                user.UserName = username;
                user.Email = email;
                user.PhoneNumber = phone;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}