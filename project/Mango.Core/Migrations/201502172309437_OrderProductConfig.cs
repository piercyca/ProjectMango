namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderProductConfig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLineItem", "Configuration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderLineItem", "Configuration");
        }
    }
}
