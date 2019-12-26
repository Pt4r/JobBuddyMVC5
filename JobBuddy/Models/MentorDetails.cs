using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class MentorDetails
    {
        public Guid  MentorId { get; set; }

        public string PhoneNumber { get; set; }

        //fk user
        //fk job categories
       

        public string Rating { get; set; }

        public string ProfilePicture { get; set; }

        public Gender Gender { get; set; }

        public string Description { get; set; }

        public IEnumerable<MentorOffer> OffersReceived { get; set; }

        //enas mentor mporei na douleuei se company optional 1-many rel.
        public Company Company { get; set; }

        public Guid CompanyId { get; set; }
    }
}