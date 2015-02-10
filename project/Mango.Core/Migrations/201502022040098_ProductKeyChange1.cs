namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductKeyChange1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductCategories");
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.ProductCategories", "Id");
            DropColumn("dbo.Products", "Id");
            AddColumn("dbo.ProductCategories", "ProductCategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "ProductId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "ProductCategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductCategories", "ProductCategoryId");
            AddPrimaryKey("dbo.Products", "ProductId");
            CreateIndex("dbo.Products", "ProductCategoryId");
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "ProductCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ProductCategories", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.ProductCategories");
            DropColumn("dbo.Products", "ProductCategoryId");
            DropColumn("dbo.Products", "ProductId");
            DropColumn("dbo.ProductCategories", "ProductCategoryId");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.ProductCategories", "Id");
        }
    }
}
