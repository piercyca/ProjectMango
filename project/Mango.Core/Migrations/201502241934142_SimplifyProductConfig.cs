namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyProductConfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductConfig", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductConfig", new[] { "ProductId" });
            DropIndex("dbo.ProductConfig", new[] { "Version" });
            AddColumn("dbo.Product", "Configuration", c => c.String(nullable: false));
            DropTable("dbo.ProductConfig");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductConfig",
                c => new
                    {
                        ProductConfigId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Configuration = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductConfigId);
            
            DropColumn("dbo.Product", "Configuration");
            CreateIndex("dbo.ProductConfig", "Version");
            CreateIndex("dbo.ProductConfig", "ProductId");
            AddForeignKey("dbo.ProductConfig", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
    }
}
