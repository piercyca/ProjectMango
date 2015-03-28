namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductUrlSlugUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Product", "UrlSlug", unique: true, name: "IX_Product_UrlSlug");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "IX_Product_UrlSlug");
        }
    }
}
