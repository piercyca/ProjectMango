namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTweaks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "Country", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Address", "Country", c => c.String(maxLength: 2));
        }
    }
}
