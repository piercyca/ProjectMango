namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "State", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Address", "State", c => c.String(maxLength: 50));
        }
    }
}
