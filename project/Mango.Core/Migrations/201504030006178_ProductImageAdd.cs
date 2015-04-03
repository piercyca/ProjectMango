namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductImageAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SortOrder })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductImage", new[] { "ProductId" });
            DropTable("dbo.ProductImage");
        }
    }
}
