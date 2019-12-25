using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public  enum enumJobCategoryTitle { IT , Economics, Marketing, Sales, Engineering, Healthcare, Arts, Tourism, CustomerSupport } 
    public class JobCategory
    {   
        public Guid IdJC { get; set; }
        public enumJobCategoryTitle JobCategoryTitle { get; set; }
        public string Subcategory111 { get; set; }
        public string Subcategory222 { get; set; }

    }
}