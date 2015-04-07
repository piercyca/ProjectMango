namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrganizationImageRemovePrimaryLogoImageField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Organization", "PrimaryLogoImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organization", "PrimaryLogoImage", c => c.String());
        }
    }
}
