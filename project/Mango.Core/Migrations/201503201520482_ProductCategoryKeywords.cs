namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategoryKeywords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "Keywords", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategory", "Keywords");
        }
    }
}
