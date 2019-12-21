using JobBuddy.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class HrDetails
    {
        public int Id { get; set; }
        public Company Company {get;set;}
        public List<JobListing> JobListings { get; set; }
        public int PhoneNumber { get; set; }
        public string ProfilePic { get; set; }

    }
}