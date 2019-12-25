using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class Mentors_MentorOffersViewModel
    {
        public MentorDetails Mentor { get; set; }

        public IEnumerable<MentorOffer> Offers { get; set; }
    }
}