namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
