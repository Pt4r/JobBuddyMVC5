using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobBuddy.Models
{
    public class AdministratorUserDetails  // apo ApplicationUser 
    {
        public Guid Id { get; set; }

        //To idio se olous .. Dimiourgo foreign key me aspnetusers

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

    }
}