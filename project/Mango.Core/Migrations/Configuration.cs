using System.Data.Entity.Core.Objects.DataClasses;
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
            // Delete products and product categories because they've been being silly when updating because of their unique contraints.
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Product]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[ProductCategory]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Order]");

            #region Product Categories

            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory
            {
                Name = "Drinkware",
                Description = "Drinkware description",
                ProductCategoryId = 1,
                UrlSlug = "drinkware",
                Keywords = "cup,mug,drink"
            });
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory
            {
                Name = "Granite",
                Description = "Granite description",
                ProductCategoryId = 2,
                UrlSlug = "granite",
                Keywords = "granite,sign"
            });
            context.ProductCategories.AddOrUpdate(pc => pc.ProductCategoryId, new ProductCategory
            {
                Name = "Ornaments",
                Description = "This category includes holiday related items such as ornaments and panels",
                ProductCategoryId = 4,
                UrlSlug = "ornaments",
                Keywords = "holiday,ornamenets,glass"
            });

            #endregion

            #region Products

            context.Products.AddOrUpdate(p => 
                new { p.ProductId, p.UrlSlug },
                         new Entity.Product
                         {
                             Name = "Coffee Mug - Black",
                             Price = 10.15m,
                             ProductId = 1,
                             ProductCategoryId = 1,
                             Configuration = "{\"layout\":{\"pic\": {\"top\":181,\"left\":117,\"width\":193,\"height\":151}}}",
                             CanvasImage = "https://mangoassets.blob.core.windows.net/images/0a59f9ee37564e33bcf36b8f6e73866d.png",
                             UrlSlug = "coffee-cup-black",
                             Description = "11 Oz. Traditional Personalized Ceramic Coffee Mug "
                         },
                        new Entity.Product
                        {
                            Name = "Glass Beer Mug",
                            Price = 15.5m,
                            ProductId = 2,
                            ProductCategoryId = 1,
                            Configuration = "{\"layout\":{\"pic\": {\"top\":157,\"left\":104,\"width\":175,\"height\":200}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/51d6993c67574ae1b0ad0c1a9b94dba1.png",
                            UrlSlug = "glass-beer-mug",
                            Description = "Get this item with a customized clear laser engraving "
                        },
                        new Entity.Product
                        {
                            Name = "Welcome Plaque - Granite",
                            Price = 175m,
                            ProductId = 3,
                            ProductCategoryId = 2,
                            Configuration = "{\"layout\":{\"text\": {\"top\":200,\"left\":111,\"width\":286,\"height\":276},\"pic\": {\"top\":43,\"left\":140,\"width\":222,\"height\":130}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/28e552c9b0b84fcb8dcee37ab3ca772b.jpg",
                            UrlSlug = "welcome-sign-granite-slate",
                            Description = "Get this item with a customized clear laser engraving "
                        },
                        new Entity.Product
                        {
                            Name = "Coffee Mug - White",
                            Price = 12.01m,
                            ProductId = 4,
                            ProductCategoryId = 1,
                            Configuration = "{\"layout\":{\"pic\": {\"top\":155,\"left\":98,\"width\":204,\"height\":200}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/c8da200e2c7d48ec8e63352d03d3a045.png",
                            UrlSlug = "white-coffee-mug",
                            Description = "11 Oz. Traditional Personalized Ceramic Coffee Mug"
                        },
                        new Entity.Product
                        {
                            Name = "Glass Coffee Cup",
                            Price = 15.5m,
                            ProductId = 5,
                            ProductCategoryId = 1,
                            Configuration = "{\"layout\":{\"pic\": {\"top\":94,\"left\":173,\"width\":230,\"height\":200}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/10edf6c0036b46759b137765d29733e5.png",
                            UrlSlug = "glass-coffee-cup",
                            Description = "Get this item with a customized clear laser engraving "
                        },
                        new Entity.Product
                        {
                            Name = "Octagon Address Plate",
                            Price = 10.15m,
                            ProductId = 6,
                            ProductCategoryId = 2,
                            Configuration = "{\"layout\":{\"text\": {\"top\":211,\"left\":88,\"width\":340,\"height\":200},\"pic\": {\"top\":69,\"left\":126,\"width\":269,\"height\":134}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/b5c7fd8cfba447a5942bd37bb07cc12b.jpg",
                            UrlSlug = "octagon-address-plate",
                            Description = "Black Granite Polished with half inch raised edge. Letters sandblasted in, painted letters \nSize: 10\"L x 8\"W"
                        },
                        new Entity.Product
                        {
                            Name = "Ornament - Round",
                            Price = 12.95m,
                            ProductId = 7,
                            ProductCategoryId = 4,
                            Configuration = "{\"layout\":{\"text\": {\"top\":264,\"left\":89,\"width\":326,\"height\":200},\"pic\": {\"top\":98,\"left\":153,\"width\":204,\"height\":162}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/3484beb037c5492992db7868bb1b5ee0.png",
                            UrlSlug = "glass-round-ornament",
                            Description = "The glass ornaments are a clear optical glass with beveled edges. The engraving appears a frosty white."
                        },
                        new Entity.Product
                        {
                            Name = "Rocks Style Shot Glass",
                            Price = 55m,
                            ProductId = 8,
                            ProductCategoryId = 1,
                            Configuration = "{\"layout\":{\"pic\": {\"top\":143,\"left\":150,\"width\":213,\"height\":165}}}",
                            CanvasImage = "https://mangoassets.blob.core.windows.net/images/51d1a2aecbe449f2950b7fa2ec30ed57.png",
                            UrlSlug = "rocks-shot-glass",
                            Description = "Get this item with a customized clear laser engraving "
                        });

                        // Product Images
                        context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage
                        {
                            ProductId = 1,
                            SortOrder = 0,
                            Url = "https://mangoassets.blob.core.windows.net/images/b85829efdf3e4d79adf93101e0adbdaa.png"
                        });
                        context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage
                        {
                            ProductId = 2,
                            SortOrder = 0,
                            Url = "https://mangoassets.blob.core.windows.net/images/504022dac3ac4894a2e879a0e5749cc9.png"
                        });
                        context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage
                        {
                            ProductId = 3,
                            SortOrder = 0,
                            Url = "https://mangoassets.blob.core.windows.net/images/e9c57261111848a1955fafe16648f8de.jpg"
                        });
                        context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage
                        {
                            ProductId = 4,
                            SortOrder = 0,
                            Url = "https://mangoassets.blob.core.windows.net/images/ab8108a592c7423f87377d93342f8ede.png"
                        });
                        context.ProductImages.AddOrUpdate(pi => new { pi.ProductId, pi.SortOrder }, new ProductImage
                        {
                            ProductId = 5,
                            SortOrder = 0,
                            Url = "https://mangoassets.blob.core.windows.net/images/b569b1114f6848e5a2d4ca77faedaa2a.png"
                        });
            
            #endregion

            #region Organizations

            context.Organizations.AddOrUpdate(o => o.OrganizationId, 
                new Organization { OrganizationId = 1, Name = "University of Georgia", Abbreviation = "UGA"},
                new Organization { OrganizationId = 2, Name = "Georgia Institute of Technology", Abbreviation = "GTech" });

            #endregion

            #region Organization Images

            context.OrganizationImages.AddOrUpdate(pi => new { pi.OrganizationId, pi.SortOrder },
                new OrganizationImage { OrganizationId = 1, SortOrder = 0, Url = "https://mangoassets.blob.core.windows.net/images/784a1ad990fc447881ea0f94750f99e4.png"},
                new OrganizationImage { OrganizationId = 1, SortOrder = 1, Url = "https://mangoassets.blob.core.windows.net/images/2977ea2bad1a4a54863eb5de18c7c081.png"}, 
                new OrganizationImage { OrganizationId = 1, SortOrder = 2, Url = "https://mangoassets.blob.core.windows.net/images/66ac2617974146d2bab50b44058dda8b.png" });

            #endregion

            #region Customers

            context.Customers.AddOrUpdate(c => c.CustomerId, 
                new Customer
                {
                    CustomerId = 1, 
                    DateCreated = DateTime.UtcNow, 
                    Email = "customer_person@etcheive.com", 
                    FirstName = "Frank", 
                    LastName = "Customer", 
                    Username = "customer_person@etcheive.com"
                });
            //context.Customers.AddOrUpdate(c => c.CustomerId, new Entity.Customer { CustomerId = 2, DateCreated = DateTime.UtcNow, Email = "guest@etchieve.com", FirstName = "Guest", LastName = "Customer", Username = null });

            #endregion

            #region Adresses

            context.Addresses.AddOrUpdate(a => a.AddressId, 
                new Address
                {
                    AddressId = 1, 
                    Status = AddressStatus.Active, 
                    AddressType = AddressType.Ship, 
                    FirstName = "John", 
                    LastName = "Smith", 
                    Phone = "5555555555", 
                    AddressLine1 = "33 Main St.", 
                    AddressLine2 = "Apt. 2", 
                    City = "Athens", 
                    State = "GA", 
                    Zip = "30605", 
                    County = "Fulton",
                    Country = "USA", 
                    DateCreated = DateTime.Now
                }); 
                //new Address { AddressId = 2, Status = AddressStatus.Active, AddressType = AddressType.Ship, FirstName = "John", LastName = "Smith", Phone = "7777777777", AddressLine1 = "157 Broad Ave.", AddressLine2 = "", City = "Atlanta", State = "GA", Zip = "30303", Country = "USA", DateCreated = DateTime.Now }

            #endregion

            #region Orders
			
            context.Orders.AddOrUpdate(o => o.OrderId, 
                new Entity.Order
                {
                    OrderId = 1, 
                    CustomerId = 1, 
                    ShipAddressId = 1, 
                    //BillAddressId = 1, 
                    TotalAmount = 100.00m, 
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DateShipped = null
                });

            #endregion

            #region Order Line Items
			
            context.OrderLineItems.AddOrUpdate(ol => ol.OrderId, 
                new OrderLineItem { OrderId = 1, OrderItemSequence = 1, ProductId = 1, UnitPrice = 22.50m, Quantity = 2, Configuration = "{\"layout\":{\"pic\":{\"top\":112,\"left\":111,\"width\":297,\"height\":136},\"text\":{\"top\":294,\"left\":133,\"width\":248,\"height\":114}}}" },
                new OrderLineItem { OrderId = 1, OrderItemSequence = 2, ProductId = 2, UnitPrice = 15.50m, Quantity = 5, Configuration = "{\"layout\":{\"pic\":{\"top\":112,\"left\":111,\"width\":297,\"height\":136},\"text\":{\"top\":294,\"left\":133,\"width\":248,\"height\":114}}}" });

            #endregion
        }
    }
}
