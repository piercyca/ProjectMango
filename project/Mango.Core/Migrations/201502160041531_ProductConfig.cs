namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductConfigs",
                c => new
                    {
                        ProductConfigId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Configuration = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductConfigId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Version);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductConfigs", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductConfigs", new[] { "Version" });
            DropIndex("dbo.ProductConfigs", new[] { "ProductId" });
            DropTable("dbo.ProductConfigs");
        }
    }
}
