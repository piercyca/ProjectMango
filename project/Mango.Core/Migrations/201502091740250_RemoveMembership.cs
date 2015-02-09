namespace Mango.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMembership : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Memberships", "UserId", "dbo.Users");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UsersInRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Memberships", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Roles", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Users", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.Memberships", new[] { "UserId" });
            DropIndex("dbo.Memberships", new[] { "ApplicationId" });
            DropIndex("dbo.Users", new[] { "ApplicationId" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "ApplicationId" });
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.UsersInRoles", new[] { "UserId" });
            DropTable("dbo.Applications");
            DropTable("dbo.Memberships");
            DropTable("dbo.Users");
            DropTable("dbo.Profiles");
            DropTable("dbo.Roles");
            DropTable("dbo.UsersInRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersInRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        ApplicationId = c.Guid(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PropertyNames = c.String(nullable: false),
                        PropertyValueStrings = c.String(nullable: false),
                        PropertyValueBinary = c.Binary(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        ApplicationId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        IsAnonymous = c.Boolean(nullable: false),
                        LastActivityDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        ApplicationId = c.Guid(nullable: false),
                        Password = c.String(nullable: false, maxLength: 128),
                        PasswordFormat = c.Int(nullable: false),
                        PasswordSalt = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        PasswordQuestion = c.String(maxLength: 256),
                        PasswordAnswer = c.String(maxLength: 128),
                        IsApproved = c.Boolean(nullable: false),
                        IsLockedOut = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        LastPasswordChangedDate = c.DateTime(nullable: false),
                        LastLockoutDate = c.DateTime(nullable: false),
                        FailedPasswordAttemptCount = c.Int(nullable: false),
                        FailedPasswordAttemptWindowStart = c.DateTime(nullable: false),
                        FailedPasswordAnswerAttemptCount = c.Int(nullable: false),
                        FailedPasswordAnswerAttemptWindowsStart = c.DateTime(nullable: false),
                        Comment = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Guid(nullable: false),
                        ApplicationName = c.String(nullable: false, maxLength: 235),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateIndex("dbo.UsersInRoles", "UserId");
            CreateIndex("dbo.UsersInRoles", "RoleId");
            CreateIndex("dbo.Roles", "ApplicationId");
            CreateIndex("dbo.Profiles", "UserId");
            CreateIndex("dbo.Users", "ApplicationId");
            CreateIndex("dbo.Memberships", "ApplicationId");
            CreateIndex("dbo.Memberships", "UserId");
            AddForeignKey("dbo.Users", "ApplicationId", "dbo.Applications", "ApplicationId");
            AddForeignKey("dbo.Roles", "ApplicationId", "dbo.Applications", "ApplicationId");
            AddForeignKey("dbo.Memberships", "ApplicationId", "dbo.Applications", "ApplicationId");
            AddForeignKey("dbo.UsersInRoles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Memberships", "UserId", "dbo.Users", "UserId");
        }
    }
}
