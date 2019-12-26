using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobBuddy.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {  
        public DbSet<JobCategory> JobCategories { get; set; }
    
    
        public DbSet<ClientUserDetails> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<MentorDetails> Mentors { get; set; }

        public DbSet<MentorOffer> MentorOffers { get; set; }
        public DbSet<HrUserDetails> HrDetails { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public ApplicationDbContext()
            : base("LocalDb", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorDetails>()
                        .HasKey(m => m.MentorId);



            modelBuilder.Entity<MentorDetails>()
                        .Property(m => m.Description)
                        .IsRequired()
                        .HasMaxLength(1000);

            modelBuilder.Entity<MentorDetails>()
                       .Property(m => m.PhoneNumber)
                       .IsRequired();

            modelBuilder.Entity<MentorDetails>()
                      .Property(m => m.Gender)
                      .IsRequired();

            modelBuilder.Entity<MentorOffer>()
                        .HasRequired(mo => mo.Mentor)
                        .WithMany(m => m.OffersReceived.ToList())
                        .HasForeignKey(mo => mo.MentorId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<MentorOffer>()
                        .HasKey(mo => mo.MentorOfferId);

            modelBuilder.Entity<MentorOffer>()
                        .Property(mo => mo.OfferStatus)
                        .IsRequired();

            modelBuilder.Entity<MentorOffer>()
                     .Property(mo => mo.ExpirationDate)
                     .IsRequired();

            modelBuilder.Entity<MentorOffer>()
                     .Property(mo => mo.PostDate)
                     .IsRequired();

            modelBuilder.Entity<MentorOffer>()
                    .Property(mo => mo.MentorId)
                    .IsRequired();


            modelBuilder.Entity<HrUserDetails>().ToTable("HrUser");
            modelBuilder.Entity<HrUserDetails>().HasKey(i => i.Id);
            modelBuilder.Entity<HrUserDetails>().Property(m => m.Gender).IsRequired();
            modelBuilder.Entity<HrUserDetails>().Property(i => i.PhoneNumber).IsRequired();
            modelBuilder.Entity<HrUserDetails>().HasRequired(i => i.Company).WithMany(c => c.HrUser).HasForeignKey(i => i.CompanyId).WillCascadeOnDelete(false);
            modelBuilder.Entity<HrUserDetails>().HasMany(i => i.JobListings).WithRequired(c => c.HrUser).HasForeignKey(c => c.HrUserId).WillCascadeOnDelete(false);

            modelBuilder.Entity<JobListing>().ToTable("JobListing");
            modelBuilder.Entity<JobListing>().HasKey(i => i.Id);
            modelBuilder.Entity<JobListing>().Property(i => i.Title).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<JobListing>().Property(i => i.Info).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<JobListing>().HasMany(i => i.SubmitedClients).WithMany(c => c.JobListings).Map(s => s.ToTable("ClientSubmitedJobListings"));
            modelBuilder.Entity<JobListing>().HasRequired(i => i.JobCategory).WithMany(c => c.JobListings).HasForeignKey(i => i.JobCategoryId).WillCascadeOnDelete(false);


            // Pws tha paroume tin etairia tou HrDetail User na tin kanoume assign sto jobListing??

            //base.OnModelCreating(modelBuilder);
        }
    }
}


    