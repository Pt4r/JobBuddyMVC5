using JobBuddy.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class HrDetail
    {
        public int Id { get; set; }
        public Company HrCompany { get; set; }
        public int CompanyId { get; set; }
        public List<JobListing> JobListings { get; set; }
        public int PhoneNumber { get; set; }
        public byte ProfilePic { get; set; }

    }
}