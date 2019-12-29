namespace JobBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SynchronizeUserWithMentorDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MentorDetails", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MentorDetails", "ApplicationUserId");
            AddForeignKey("dbo.MentorDetails", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MentorDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MentorDetails", new[] { "ApplicationUserId" });
            DropColumn("dbo.MentorDetails", "ApplicationUserId");
        }
    }
}
