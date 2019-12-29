namespace JobBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditingAspnetUsersRolesandaddingtablescompaniesmentorsmentorDetailsMentoroffers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.MentorDetails",
                c => new
                    {
                        MentorId = c.Guid(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        Rating = c.String(nullable: false),
                        ProfilePicture = c.String(name: "[Profile Picture]"),
                        Gender = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 2000),
                        CompanyId = c.Guid(),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.MentorOffers",
                c => new
                    {
                        MentorOfferId = c.Guid(nullable: false),
                        MentorId = c.Guid(nullable: false),
                        OfferStatus = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MentorOfferId)
                .ForeignKey("dbo.MentorDetails", t => t.MentorId)
                .Index(t => t.MentorId);
            
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MentorOffers", "MentorId", "dbo.MentorDetails");
            DropForeignKey("dbo.MentorDetails", "CompanyId", "dbo.Companies");
            DropIndex("dbo.MentorOffers", new[] { "MentorId" });
            DropIndex("dbo.MentorDetails", new[] { "CompanyId" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropTable("dbo.MentorOffers");
            DropTable("dbo.MentorDetails");
            DropTable("dbo.Companies");
        }
    }
}
