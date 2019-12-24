using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JobBuddy.Models.Job;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobBuddy.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HrDetail> HrDetails { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public ApplicationDbContext()
            : base("PasparakisDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrDetail>().ToTable("HrUser").HasKey(i => i.Id);
            modelBuilder.Entity<HrDetail>().Property(i => i.PhoneNumber).IsRequired();
            modelBuilder.Entity<HrDetail>().HasRequired(i => i.HrCompany).WithMany(c => c.HrUser).HasForeignKey(i => i.CompanyId);
            modelBuilder.Entity<HrDetail>().HasMany(i => i.JobListings).WithRequired(c => c.HrUser).HasForeignKey(c => c.HrUserId);

            base.OnModelCreating(modelBuilder);
        }


    }
}