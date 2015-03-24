namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategoryUrlSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "UrlSlug", c => c.String(nullable: false, maxLength: 20, unicode: false));
            CreateIndex("dbo.ProductCategory", "UrlSlug", unique: true, name: "IX_ProductCategory_UrlSlug");
            DropColumn("dbo.ProductCategory", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategory", "Code", c => c.String(nullable: false, maxLength: 20));
            DropIndex("dbo.ProductCategory", "IX_ProductCategory_UrlSlug");
            DropColumn("dbo.ProductCategory", "UrlSlug");
        }
    }
}
