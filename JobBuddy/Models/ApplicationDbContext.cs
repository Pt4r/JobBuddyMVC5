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
        public DbSet<MentorDetails> Mentors { get; set; }

        public DbSet<MentorOffer> MentorOffers { get; set; }
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
              modelBuilder.Entity<MentorDetails>()
                        .HasKey(m => m.MentorId);

              modelBuilder.Entity<MentorDetails>()
                       .Property(m => m.PhoneNumber)
                       .HasMaxLength(25)
                       .IsRequired();

             //Πρέπει να δω πώς θα μπει το Rating ..Προς το παρόν μόνο Required
             modelBuilder.Entity<MentorDetails>()
                       .Property(m => m.Rating)
                       .IsRequired(); 
            //episis na doume pws mpainei kai ti length...
             modelBuilder.Entity<MentorDetails>()
                       .Property(m => m.ProfilePicture)
                       .IsOptional()
                       .HasColumnName("[Profile Picture]");


            modelBuilder.Entity<MentorDetails>()
                      .Property(m => m.Gender)
                      .IsRequired();

            modelBuilder.Entity<MentorDetails>()
                        .Property(m => m.Description)
                        .IsRequired()
                        .HasMaxLength(2000);

            //Company-Mentor relationship
            modelBuilder.Entity<MentorDetails>()
                        .HasOptional(m=>m.Company)
                        .WithMany(c=>c.Mentors)
                        .HasForeignKey(m=>m.CompanyId)
                        .WillCascadeOnDelete(false);

            //Mentor-MentorOffer Relationship
            modelBuilder.Entity<MentorOffer>()
                        .HasRequired(mo => mo.Mentor)
                        .WithMany(m=>m.OffersReceived.ToList())
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

            //base.OnModelCreating(modelBuilder);
        }
    }

}