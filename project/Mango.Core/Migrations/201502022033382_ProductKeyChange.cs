namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductKeyChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropPrimaryKey("dbo.ProductCategories");
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.ProductCategories", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductCategories", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            DropColumn("dbo.ProductCategories", "ProductCategoryId");
            DropColumn("dbo.Products", "ProductId");
            DropColumn("dbo.Products", "ProductCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductCategoryId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "ProductId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductCategories", "ProductCategoryId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.ProductCategories");
            DropColumn("dbo.Products", "Id");
            DropColumn("dbo.ProductCategories", "Id");
            AddPrimaryKey("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.ProductCategories", "ProductCategoryId");
            CreateIndex("dbo.Products", "ProductCategoryId");
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "ProductCategoryId", cascadeDelete: true);
        }
    }
}
