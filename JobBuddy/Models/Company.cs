using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public List<MentorDetails> Mentors { get; set; }
    }
}