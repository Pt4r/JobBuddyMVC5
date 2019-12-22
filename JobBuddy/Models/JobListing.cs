using JobBuddy.Models.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models.Job
{
    public class JobListing
    {
        //+ HR :type 

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; }
        public string Info { get; set; }
        public JobCategory JobCategory { get; set; }
        public List<Client> SubmitedClients { get; set; }
        public Company Company { get; set; }

        public JobListing()
        {
            PostDate = DateTime.Now;
        }

    }
}