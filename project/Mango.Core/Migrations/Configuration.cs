using Mango.Core.Entities;

namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mango.Core.Entities.MangoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MangoContext context)
        {
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 1, Code = "P", Name = "Product", Description = "Product" });
            context.Products.AddOrUpdate(p => 
                p.ProductId,
                new Entities.Product { Code = "P1", Name = "Granite platter rectangle w/handles", Price = 22.50m, ProductCategoryId = 1, ProductId = 1 },
                new Entities.Product { Code = "P2", Name = "Granite state of Georgia platter", Price = 15.50m, ProductCategoryId = 1, ProductId = 2 });
        }
    }
}
