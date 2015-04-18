namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderPayPalFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "PayPalPayerId", c => c.String());
            AddColumn("dbo.Order", "PayPalEmail", c => c.String());
            AddColumn("dbo.Order", "PayPalToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "PayPalToken");
            DropColumn("dbo.Order", "PayPalEmail");
            DropColumn("dbo.Order", "PayPalPayerId");
        }
    }
}
