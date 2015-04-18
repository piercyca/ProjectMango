namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAddressLine3DunnoWhyIDidThat : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Address", "AddressLine3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "AddressLine3", c => c.String(maxLength: 200));
        }
    }
}
