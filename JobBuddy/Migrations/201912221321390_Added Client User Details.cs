namespace JobBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientUserDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientUserDetails",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        ProfilePicture = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        CurrentStatus = c.Int(nullable: false),
                        LookingForStatus = c.Int(nullable: false),
                        CV = c.String(),
                        CoverLetter = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientUserDetails");
        }
    }
}
