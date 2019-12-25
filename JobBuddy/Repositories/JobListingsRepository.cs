using JobBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Repositories
{
    public class JobListingsRepository
    {


        public IEnumerable<JobListing> GetJobListings()
        {
            IEnumerable<JobListing> jobListings;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                jobListings = db.JobListings.ToList();
            }

            return jobListings;
        }

        public void AddJobListing(JobListing jobListing)
        {
            if (jobListing == null)
            {
                throw new ArgumentNullException();
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                jobListing.Id = Guid.NewGuid();
                db.JobListings.Add(jobListing);
                db.SaveChanges();
            }
        }

        public void UpdateJobListing(JobListing jobListing)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.JobListings.Attach(jobListing);
                db.Entry(jobListing).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteJobListing(Guid id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var jobListing = db.JobListings.Find(id);
                db.JobListings.Remove(jobListing);
                db.SaveChanges();
            }
        }

        public JobListing FindJobListingById(Guid id)
        {
            JobListing jobListing;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                jobListing = db.JobListings.Find(id);
            }

            return jobListing;
        }
    }

}
