using JobBuddy.Models;
using JobBuddy.Models.Job;
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

        public void AddJobListing(string title, string info, JobCategory jobcat, Company company)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.JobListings.Add(new JobListing
                {
                    Title = title,
                    Info = info,
                    PostDate = DateTime.Now,
                    JobCategory = jobcat,
                    Company = company
                });

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

        public void DeleteJobListing(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var artist = db.JobListings.Find(id);
                db.JobListings.Remove(artist);
                db.SaveChanges();
            }
        }

        public JobListing FindById(int id)
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
