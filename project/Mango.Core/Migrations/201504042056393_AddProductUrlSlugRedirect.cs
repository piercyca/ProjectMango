namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductUrlSlugRedirect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductUrlSlugRedirect",
                c => new
                    {
                        OldUrlSlug = c.String(nullable: false, maxLength: 128),
                        NewUrlSlug = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OldUrlSlug);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductUrlSlugRedirect");
        }
    }
}
