namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUnPluralization : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Addresses", newName: "Address");
            RenameTable(name: "dbo.OrderLineItems", newName: "OrderLineItem");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.ProductCategories", newName: "ProductCategory");
            RenameTable(name: "dbo.ProductConfigs", newName: "ProductConfig");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductConfig", newName: "ProductConfigs");
            RenameTable(name: "dbo.ProductCategory", newName: "ProductCategories");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.OrderLineItem", newName: "OrderLineItems");
            RenameTable(name: "dbo.Address", newName: "Addresses");
        }
    }
}
