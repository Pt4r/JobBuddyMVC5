namespace JobBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingAdminsrole : DbMigration
    {
        public override void Up()
        {
            Sql(@"Update dbo.AspNetUsers Set UserRole='Admin' where FirstName='Head'");
        }
        
        public override void Down()
        {
        }
    }
}
