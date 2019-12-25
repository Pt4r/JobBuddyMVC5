using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public enum Gender { }
    public class HrDetail
    {
        public Guid Id { get; set; }
        public Gender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public byte ProfilePic { get; set; }
        public Company HrCompany { get; set; }
        public Guid CompanyId { get; set; }
        public List<JobListing> JobListings { get; set; }

    }
}