namespace JobBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildTheDatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MentorUserDetails", name: "ProfilePicture", newName: "[Profile Picture]");
            RenameColumn(table: "dbo.MentorUserDetails", name: "Company_Id", newName: "CompanyId");
            RenameIndex(table: "dbo.MentorUserDetails", name: "IX_Company_Id", newName: "IX_CompanyId");
            CreateTable(
                "dbo.AdministratorUserDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.ClientUserDetails", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.HrUser", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.MentorUserDetails", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String(nullable: false));
            AlterColumn("dbo.MentorUserDetails", "PhoneNumber", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.MentorUserDetails", "Rating", c => c.Byte(nullable: false));
            AlterColumn("dbo.MentorUserDetails", "Description", c => c.String(nullable: false, maxLength: 2000));
            CreateIndex("dbo.ClientUserDetails", "ApplicationUserId");
            CreateIndex("dbo.HrUser", "ApplicationUserId");
            CreateIndex("dbo.MentorUserDetails", "ApplicationUserId");
            AddForeignKey("dbo.ClientUserDetails", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.HrUser", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MentorUserDetails", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MentorUserDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HrUser", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClientUserDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdministratorUserDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MentorUserDetails", new[] { "ApplicationUserId" });
            DropIndex("dbo.HrUser", new[] { "ApplicationUserId" });
            DropIndex("dbo.AdministratorUserDetails", new[] { "ApplicationUserId" });
            DropIndex("dbo.ClientUserDetails", new[] { "ApplicationUserId" });
            AlterColumn("dbo.MentorUserDetails", "Description", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.MentorUserDetails", "Rating", c => c.Byte());
            AlterColumn("dbo.MentorUserDetails", "PhoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropColumn("dbo.MentorUserDetails", "ApplicationUserId");
            DropColumn("dbo.HrUser", "ApplicationUserId");
            DropColumn("dbo.ClientUserDetails", "ApplicationUserId");
            DropTable("dbo.AdministratorUserDetails");
            RenameIndex(table: "dbo.MentorUserDetails", name: "IX_CompanyId", newName: "IX_Company_Id");
            RenameColumn(table: "dbo.MentorUserDetails", name: "CompanyId", newName: "Company_Id");
            RenameColumn(table: "dbo.MentorUserDetails", name: "[Profile Picture]", newName: "ProfilePicture");
        }
    }
}
