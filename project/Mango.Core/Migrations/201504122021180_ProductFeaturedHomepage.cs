namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductFeaturedHomepage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "FeaturedHomepage", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "FeaturedHomepage");
        }
    }
}
