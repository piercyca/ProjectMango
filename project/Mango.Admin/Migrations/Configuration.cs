using System.Collections.Generic;
using Mango.Admin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mango.Admin.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Seed Roles
            var roleNames = new [] { "Admin", "Customer" };
            foreach (var roleName in roleNames)
            {
                // Check to see if Role Exists, if not create it
                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }

            // Seed Test Users
            var seedUsers = new List<dynamic>
            {
                new {name = "customer_person@etcheive.com", role = "Customer" },
                new {name = "admin_person@etcheive.com", role = "Admin"},
            };
            
            foreach (var seedUser in seedUsers)
            {
                string seedUserName = seedUser.name;
                string seedRoleName = seedUser.role;

                if (!(context.Users.Any(u => u.UserName == seedUserName)))
                {
                    var userToInsert = new ApplicationUser { UserName = seedUserName, PhoneNumber = "770-555-5555" };
                    userManager.Create(userToInsert, "abc123!!");
                }

                var user = context.Users.FirstOrDefault(u => u.UserName == seedUserName);
                if (user != null && !userManager.GetRoles(user.Id).Contains(seedRoleName))
                {
                    userManager.AddToRole(user.Id, seedRoleName);
                }
            }

            var userCMO = context.Users.FirstOrDefault(u => u.UserName == "craigmoliver@gmail.com");
            if (userCMO != null && !userManager.GetRoles(userCMO.Id).Contains("Admin"))
            {
                userManager.AddToRole(userCMO.Id, "Admin");
            }
        }
    }
}
