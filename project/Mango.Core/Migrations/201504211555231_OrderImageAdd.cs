namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderImageAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLineItem", "OrderImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderLineItem", "OrderImage");
        }
    }
}
