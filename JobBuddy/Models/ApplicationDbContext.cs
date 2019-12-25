using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobBuddy.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {   public DbSet<JobCategory> JobCategories { get; set; }
        public ApplicationDbContext()
            : base("PasparakisDB", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}