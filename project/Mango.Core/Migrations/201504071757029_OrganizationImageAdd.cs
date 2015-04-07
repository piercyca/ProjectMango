namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrganizationImageAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationImage",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrganizationId, t.SortOrder })
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganizationImage", "OrganizationId", "dbo.Organization");
            DropIndex("dbo.OrganizationImage", new[] { "OrganizationId" });
            DropTable("dbo.OrganizationImage");
        }
    }
}
