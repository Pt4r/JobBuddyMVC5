﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JobBuddy.Models;

namespace JobBuddy.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public List<HrUserDetails> HrUser { get; set; }
        public List<JobListing> JobListings { get; set; }

        //Lista me mentors 
        public List<MentorUserDetails> Mentors { get; set; }
        // Hr List
        //FK List Job Categories
    }
}