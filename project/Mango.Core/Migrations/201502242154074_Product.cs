namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CanvasImage", c => c.String());
            AlterColumn("dbo.Product", "Configuration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Configuration", c => c.String(nullable: false));
            DropColumn("dbo.Product", "CanvasImage");
        }
    }
}
