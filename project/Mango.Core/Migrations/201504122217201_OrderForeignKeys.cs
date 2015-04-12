namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderForeignKeys : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM [dbo].[Product]");
            Sql("DELETE FROM [dbo].[Order]");
            Sql("DELETE FROM [dbo].[Address]");
            Sql("DELETE FROM [dbo].[Customer]");
            
            DropIndex("dbo.Order", new[] { "BillAddressId" });
            AlterColumn("dbo.Order", "BillAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "BillAddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "BillAddressId" });
            AlterColumn("dbo.Order", "BillAddressId", c => c.Int());
            CreateIndex("dbo.Order", "BillAddressId");
        }
    }
}
