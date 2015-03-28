using System.Data.SqlClient;

namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductUrlSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "UrlSlug", c => c.String(nullable: false, maxLength: 200, unicode: false));
            DropColumn("dbo.Product", "Code");

            // temporary data to setup for unique constraint
            Sql("UPDATE dbo.Product SET UrlSlug = SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 9)");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Code", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Product", "UrlSlug");
        }
    }
}
