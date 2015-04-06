namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressModifications : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "FirstName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Address", "LastName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Address", "AddressLine1", c => c.String(maxLength: 200));
            AlterColumn("dbo.Address", "AddressLine2", c => c.String(maxLength: 200));
            DropColumn("dbo.Address", "Company");
            DropColumn("dbo.Address", "Attn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "Attn", c => c.String(maxLength: 100));
            AddColumn("dbo.Address", "Company", c => c.String(maxLength: 100));
            AlterColumn("dbo.Address", "AddressLine2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Address", "AddressLine1", c => c.String(maxLength: 100));
            AlterColumn("dbo.Address", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Address", "FirstName", c => c.String(maxLength: 100));
        }
    }
}
