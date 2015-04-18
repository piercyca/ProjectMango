namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderShippingFields : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Order", new[] { "BillAddressId" });
            AddColumn("dbo.Address", "AddressLine3", c => c.String(maxLength: 200));
            AddColumn("dbo.Address", "County", c => c.String(maxLength: 100));
            AddColumn("dbo.Order", "PayPalOrderId", c => c.String());
            AddColumn("dbo.Order", "PayPalOrderConfirmation", c => c.String());
            AddColumn("dbo.Order", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "DateShipped", c => c.DateTime());
            AlterColumn("dbo.Order", "BillAddressId", c => c.Int());
            CreateIndex("dbo.Order", "BillAddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "BillAddressId" });
            AlterColumn("dbo.Order", "BillAddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "DateShipped");
            DropColumn("dbo.Order", "DateUpdated");
            DropColumn("dbo.Order", "PayPalOrderConfirmation");
            DropColumn("dbo.Order", "PayPalOrderId");
            DropColumn("dbo.Address", "County");
            DropColumn("dbo.Address", "AddressLine3");
            CreateIndex("dbo.Order", "BillAddressId");
        }
    }
}
