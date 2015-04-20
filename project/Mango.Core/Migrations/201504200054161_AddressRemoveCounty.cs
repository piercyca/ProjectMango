namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressRemoveCounty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Address", "County");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "County", c => c.String(maxLength: 100));
        }
    }
}
