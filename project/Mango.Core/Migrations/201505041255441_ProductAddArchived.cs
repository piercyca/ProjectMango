namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAddArchived : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Archived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Archived");
        }
    }
}
