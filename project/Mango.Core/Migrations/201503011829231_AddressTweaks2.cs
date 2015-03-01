namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTweaks2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Address", "Nickname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "Nickname", c => c.String(maxLength: 100));
        }
    }
}
