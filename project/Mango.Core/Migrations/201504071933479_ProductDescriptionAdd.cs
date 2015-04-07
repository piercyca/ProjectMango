namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDescriptionAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Description");
        }
    }
}
