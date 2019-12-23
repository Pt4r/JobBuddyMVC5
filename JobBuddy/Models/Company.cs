using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        // Hr List
        //FK List Job Categories
    }
}