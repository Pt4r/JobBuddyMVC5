using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class ClientUserDetails
    {
        public Guid Id { get; set; }
        public string ProfilePicture { get; set; }
        public int PhoneNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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