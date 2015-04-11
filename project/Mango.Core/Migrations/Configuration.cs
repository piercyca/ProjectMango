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
            // Product Categories
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 1, UrlSlug = "drinkware", Name = "Drinkware", Description = "Drinkware description", Keywords = "cup,mug,drink" });
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 2, UrlSlug = "granite", Name = "Granite", Description = "Granite description", Keywords = "granite,sign" });
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory { ProductCategoryId = 3, UrlSlug = "cutting-board", Name = "Cutting Board", Description = "Cutting board description", Keywords = "cutting board,kitchen" });
            
            // Products
            context.Products.AddOrUpdate(p => 
                p.ProductId,
                new Entity.Product { UrlSlug = "granite-platter-rectangle-handles", Name = "Granite platter rectangle w/handles", Price = 22.50m, ProductCategoryId = 1, ProductId = 1, Configuration = "{\"layout\":{\"pic\":{\"top\":112,\"left\":111,\"width\":297,\"height\":136},\"text\":{\"top\":294,\"left\":133,\"width\":248,\"height\":114}}}", CanvasImage = "https://mangoassets.blob.core.windows.net/images/03b46d6e7ce3447fba1868358a9a69a5.jpg" },
                new Entity.Product { UrlSlug = "granite-state-georgia-platter", Name = "Granite state of Georgia platter", Price = 15.50m, ProductCategoryId = 1, ProductId = 2 });

            // Product Images
            context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage { ProductId = 1, SortOrder = 0, Url = "https://mangoassets.blob.core.windows.net/images/03b46d6e7ce3447fba1868358a9a69a5.jpg" });
            context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage { ProductId = 1, SortOrder = 1, Url = "https://mangoassets.blob.core.windows.net/images/0a1baf98f04a4f96b78ebeaa38880415.jpg" });
            context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage { ProductId = 1, SortOrder = 2, Url = "https://mangoassets.blob.core.windows.net/images/211bebb2c309483fb548c20af242e880.png" });

            // Organizations
            context.Organizations.AddOrUpdate(o => o.OrganizationId, new Organization {OrganizationId = 1, Name = "University of Georgia", Abbreviation = "UGA"});
            context.OrganizationImages.AddOrUpdate(pi => new { pi.OrganizationId, pi.SortOrder }, new OrganizationImage { OrganizationId = 1, SortOrder = 0, Url = "https://mangoassets.blob.core.windows.net/images/03b46d6e7ce3447fba1868358a9a69a5.jpg" });
            context.OrganizationImages.AddOrUpdate(pi => new { pi.OrganizationId, pi.SortOrder }, new OrganizationImage { OrganizationId = 1, SortOrder = 1, Url = "https://mangoassets.blob.core.windows.net/images/0a1baf98f04a4f96b78ebeaa38880415.jpg" });

			//Orders
			context.Orders.AddOrUpdate(o => o.OrderId, new Entity.Order {OrderId = 1, CustomerId = 1, ShipAddressId = 1, BillAddressId = 2, TotalAmount = 100.00m, DateCreated = DateTime.Now});

			//Order Line Items
			context.OrderLineItems.AddOrUpdate(ol => ol.OrderId, new Entity.OrderLineItem { OrderId = 1, OrderItemSequence = 1, ProductId = 1, UnitPrice = 22.50m, Quantity = 2, Configuration = "{\"layout\":{\"pic\":{\"top\":112,\"left\":111,\"width\":297,\"height\":136},\"text\":{\"top\":294,\"left\":133,\"width\":248,\"height\":114}}}" });
			context.OrderLineItems.AddOrUpdate(ol => ol.OrderId, new Entity.OrderLineItem { OrderId = 1, OrderItemSequence = 2, ProductId = 2, UnitPrice = 15.50m, Quantity = 5, Configuration = "" });

			//Adresses
			context.Addresses.AddOrUpdate(a => a.AddressId, new Entity.Address { AddressId = 1, Status = (AddressStatus) 1, AddressType = (AddressType) 1, FirstName = "John", LastName = "Smith", Phone = "5555555555", AddressLine1 = "33 Main St.", AddressLine2 = "Apt. 2", City = "Athens", State = "GA", Zip = "30605", Country = "USA", DateCreated = DateTime.Now});
			context.Addresses.AddOrUpdate(a => a.AddressId, new Entity.Address { AddressId = 2, Status = (AddressStatus) 1, AddressType = (AddressType) 2, FirstName = "John", LastName = "Smith", Phone = "7777777777", AddressLine1 = "157 Broad Ave.", AddressLine2 = "", City = "Atlanta", State = "GA", Zip = "30303", Country = "USA", DateCreated = DateTime.Now });
        }
    }
}
