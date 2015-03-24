using Mango.Core.Entity;

namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mango.Core.Entity.MangoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Seeds data in the perisitent store
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MangoContext context)
        {
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 1, UrlSlug = "drinkware", Name = "Drinkware", Description = "Drinkware description", Keywords = "cup,mug,drink" });
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 2, UrlSlug = "granite", Name = "Granite", Description = "Granite description", Keywords = "granite,sign" });
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 3, UrlSlug = "cutting-board", Name = "Cutting Board", Description = "Cutting board description", Keywords = "cutting board,kitchen" });
            context.Products.AddOrUpdate(p => 
                p.ProductId,
                new Entity.Product { Code = "P1", Name = "Granite platter rectangle w/handles", Price = 22.50m, ProductCategoryId = 1, ProductId = 1 },
                new Entity.Product { Code = "P2", Name = "Granite state of Georgia platter", Price = 15.50m, ProductCategoryId = 1, ProductId = 2 });


            context.Organizations.AddOrUpdate(o => o.OrganizationId, new Organization {OrganizationId = 1, Name = "University of Georgia", Abbreviation = "UGA"});
        }
    }
}
