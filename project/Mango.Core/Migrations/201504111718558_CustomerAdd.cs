namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Username", c => c.String());
            DropColumn("dbo.Customer", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "UserId", c => c.String());
            DropColumn("dbo.Customer", "Username");
        }
    }
}
