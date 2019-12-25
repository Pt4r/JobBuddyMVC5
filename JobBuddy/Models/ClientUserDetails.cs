using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class ClientUserDetails
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public enumGender Gender { get; set; }

        [Required]
        [Display(Name = "Current Employment Status")]
        public CurrentStatus CurrentStatus { get; set; }

        [Required]
        [Display(Name = "Looking for")]
        public enumLookingForStatus LookingForStatus { get; set; }

        
        public string CV { get; set; }

        [Display(Name = "Cover Letter")]
        public string CoverLetter { get; set; }

        //FK List Job Interest
        // Hr
        // Mentors
        //FK List Job Offers
    }
}