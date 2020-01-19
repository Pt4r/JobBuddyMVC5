namespace JobBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mergedfrommasterdev : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobListing",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        Info = c.String(nullable: false, maxLength: 1000),
                        PostDate = c.DateTime(nullable: false),
                        HrUserId = c.Guid(nullable: false),
                        JobCategoryId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HrUser", t => t.HrUserId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.JobCategories", t => t.JobCategoryId)
                .Index(t => t.HrUserId)
                .Index(t => t.JobCategoryId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HrUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Gender = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        ProfilePic = c.Byte(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Subcategory_1 = c.String(),
                        Subcategory_2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MentorOffers",
                c => new
                    {
                        MentorOfferId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        MentorId = c.Guid(nullable: false),
                        OfferStatus = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MentorOfferId)
                .ForeignKey("dbo.ClientUserDetails", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.MentorUserDetails", t => t.MentorId)
                .Index(t => t.ClientId)
                .Index(t => t.MentorId);
            
            CreateTable(
                "dbo.MentorUserDetails",
                c => new
                    {
                        MentorId = c.Guid(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Rating = c.Byte(),
                        ProfilePicture = c.String(),
                        Gender = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.ClientSubmittedJobListings",
                c => new
                    {
                        FK_JobListingId = c.Guid(nullable: false),
                        FK_ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.FK_JobListingId, t.FK_ClientId })
                .ForeignKey("dbo.JobListing", t => t.FK_JobListingId, cascadeDelete: true)
                .ForeignKey("dbo.ClientUserDetails", t => t.FK_ClientId, cascadeDelete: true)
                .Index(t => t.FK_JobListingId)
                .Index(t => t.FK_ClientId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MentorOffers", "MentorId", "dbo.MentorUserDetails");
            DropForeignKey("dbo.MentorUserDetails", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.MentorOffers", "ClientId", "dbo.ClientUserDetails");
            DropForeignKey("dbo.ClientSubmittedJobListings", "FK_ClientId", "dbo.ClientUserDetails");
            DropForeignKey("dbo.ClientSubmittedJobListings", "FK_JobListingId", "dbo.JobListing");
            DropForeignKey("dbo.JobListing", "JobCategoryId", "dbo.JobCategories");
            DropForeignKey("dbo.JobListing", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.JobListing", "HrUserId", "dbo.HrUser");
            DropForeignKey("dbo.HrUser", "CompanyId", "dbo.Companies");
            DropIndex("dbo.ClientSubmittedJobListings", new[] { "FK_ClientId" });
            DropIndex("dbo.ClientSubmittedJobListings", new[] { "FK_JobListingId" });
            DropIndex("dbo.MentorUserDetails", new[] { "Company_Id" });
            DropIndex("dbo.MentorOffers", new[] { "MentorId" });
            DropIndex("dbo.MentorOffers", new[] { "ClientId" });
            DropIndex("dbo.HrUser", new[] { "CompanyId" });
            DropIndex("dbo.JobListing", new[] { "CompanyId" });
            DropIndex("dbo.JobListing", new[] { "JobCategoryId" });
            DropIndex("dbo.JobListing", new[] { "HrUserId" });
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.ClientSubmittedJobListings");
            DropTable("dbo.MentorUserDetails");
            DropTable("dbo.MentorOffers");
            DropTable("dbo.JobCategories");
            DropTable("dbo.HrUser");
            DropTable("dbo.Companies");
            DropTable("dbo.JobListing");
        }
    }
}
