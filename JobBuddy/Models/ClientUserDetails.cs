using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class ClientUserDetails
    {
        public Guid id { get; set; }
        public string ProfilePicture { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public LookingForStatus LookingForStatus { get; set; }
        public string CV { get; set; }
        public string CoverLetter { get; set; }

        //FK List Job Interest
        // Hr
        // Mentors
        //FK List Job Offers
    }
}