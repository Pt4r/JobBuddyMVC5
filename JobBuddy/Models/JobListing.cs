﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class JobListing
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public DateTime PostDate { get; set; }


        public HrDetail HrUser { get; set; }
        public Guid HrUserId { get; set; }

        public JobCategory JobCategory { get; set; }
        public Guid JobCategoryId { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public List<ClientUserDetails> SubmitedClients { get; set; }

    }
}