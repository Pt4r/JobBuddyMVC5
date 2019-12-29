using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{

    public class HrUserDetails
    {
        public Guid Id { get; set; }
        public enumGender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public byte ProfilePic { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public List<JobListing> JobListings { get; set; }

        //To idio se olous .. Dimiourgo foreign key me aspnetusers

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

    }
}