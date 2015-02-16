namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        AddressType = c.Int(nullable: false),
                        Nickname = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Company = c.String(maxLength: 100),
                        Attn = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        AddressLine1 = c.String(maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Zip = c.String(maxLength: 10),
                        Country = c.String(maxLength: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.OrderLineItems",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        OrderItemSequence = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.OrderItemSequence })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ShipAddressId = c.Int(nullable: false),
                        BillAddressId = c.Int(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.BillAddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.ShipAddressId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShipAddressId)
                .Index(t => t.BillAddressId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        DateCreated = c.DateTime(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.ProductConfigs", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductConfigs", "Created");
            DropColumn("dbo.Products", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ProductConfigs", "Created", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.OrderLineItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderLineItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShipAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "BillAddressId", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "BillAddressId" });
            DropIndex("dbo.Orders", new[] { "ShipAddressId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderLineItems", new[] { "ProductId" });
            DropIndex("dbo.OrderLineItems", new[] { "OrderId" });
            DropColumn("dbo.ProductConfigs", "DateCreated");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLineItems");
            DropTable("dbo.Addresses");
        }
    }
}
