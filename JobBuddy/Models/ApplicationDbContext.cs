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
            modelBuilder.Entity<HrDetail>().ToTable("HrUser");
            modelBuilder.Entity<HrDetail>().HasKey(i => i.Id);
            modelBuilder.Entity<HrDetail>().Property(m => m.Gender).IsRequired();
            modelBuilder.Entity<HrDetail>().Property(i => i.PhoneNumber).IsRequired();
            modelBuilder.Entity<HrDetail>().HasRequired(i => i.HrCompany).WithMany(c => c.HrUser).HasForeignKey(i => i.CompanyId).WillCascadeOnDelete(false);
            modelBuilder.Entity<HrDetail>().HasMany(i => i.JobListings).WithRequired(c => c.HrUser).HasForeignKey(c => c.HrUserId).WillCascadeOnDelete(false);

            modelBuilder.Entity<JobListing>().ToTable("JobListing");
            modelBuilder.Entity<JobListing>().HasKey(i => i.Id);
            modelBuilder.Entity<JobListing>().Property(i => i.Title).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<JobListing>().Property(i => i.Info).IsRequired().HasMaxLength(1000);
            // H sxesi HrDetail - JobListing exei dilwthei pio panw, prepei na ksanadilwthei kai edw?
            modelBuilder.Entity<JobListing>().HasRequired(i => i.HrUser).WithMany(h => h.JobListings).HasForeignKey(i => i.HrUserId).WillCascadeOnDelete(false); 
            modelBuilder.Entity<JobListing>().HasMany(i => i.SubmitedClients).WithMany(c => c.JobListings).Map(s => s.ToTable("ClientSubmitedJobListings"));
            modelBuilder.Entity<JobListing>().HasRequired(i => i.JobCategory).WithMany(c => c.JobListings).HasForeignKey(i => i.JobCategoryId).WillCascadeOnDelete(false);


            // Pws tha paroume tin etairia tou HrDetail User na tin kanoume assign sto jobListing??
                                          
                                                                    
            base.OnModelCreating(modelBuilder);
        }


    }
}