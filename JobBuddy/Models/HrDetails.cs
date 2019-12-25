using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{

    public class HrDetail
    {
        public Guid Id { get; set; }
        public enumGender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public byte ProfilePic { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public List<JobListing> JobListings { get; set; }

    }
}