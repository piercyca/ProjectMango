﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mango.Admin.Models;
using Mango.Core.Entity;
using Mango.Core.Repository;
using Mango.Core.Service;

namespace Mango.Admin.Controllers
{ 
    public partial class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        [HttpGet]
        public virtual ActionResult Index()
        {
            var productCategories = _productCategoryService.GetProductCategories();
            return View(productCategories);
        }

        [HttpGet]
        public virtual ActionResult Edit(string id)
        {
            var db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            var vm = new UserViewModel();
            if (user != null)
            {
                vm.Id = user.Id;
                vm.Username = user.UserName;
                vm.Email = user.Email;
                vm.EmailConfirmed = user.EmailConfirmed;
                vm.PhoneNumber = user.PhoneNumber;
                vm.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                vm.PasswordHash = user.PasswordHash;
                vm.SecurityStamp = user.SecurityStamp;
                vm.TwoFactorEnabled = user.TwoFactorEnabled;
                vm.LockoutEndDateUtc = user.LockoutEndDateUtc;
                vm.LockoutEnabled = user.LockoutEnabled;
                vm.AccessFailedCount = user.AccessFailedCount;
            }
            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Edit(UserViewModel vm)
        {
            if (vm == null)
                throw new Exception("User info not found.");
            foreach (var e in vm.Validate())
                throw new Exception(e.ErrorMessage);
            var db = new ApplicationDbContext();
            var user = db.Users.Find(vm.Id);
            if (TryUpdateModel(user))
            {
                user.UserName = vm.Username;
                user.Email = vm.Email;
                user.EmailConfirmed = vm.EmailConfirmed;
                user.PhoneNumber = vm.PhoneNumber;
                user.PhoneNumberConfirmed = vm.PhoneNumberConfirmed;
                user.PasswordHash = vm.PasswordHash;
                user.SecurityStamp = vm.SecurityStamp;
                user.TwoFactorEnabled = vm.TwoFactorEnabled;
                user.LockoutEndDateUtc = vm.LockoutEndDateUtc;
                user.LockoutEnabled = vm.LockoutEnabled;
                user.AccessFailedCount = vm.AccessFailedCount;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}