namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CombineNamesToFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "FullName", c => c.String(maxLength: 300));
            AddColumn("dbo.Customer", "FullName", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Address", "FirstName");
            DropColumn("dbo.Address", "LastName");
            DropColumn("dbo.Customer", "FirstName");
            DropColumn("dbo.Customer", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Address", "LastName", c => c.String(maxLength: 150));
            AddColumn("dbo.Address", "FirstName", c => c.String(maxLength: 150));
            DropColumn("dbo.Customer", "FullName");
            DropColumn("dbo.Address", "FullName");
        }
    }
}
