using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobBuddy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Admin,User klp
        public string UserRole { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<MentorDetails> MentorDetails { get; set; }


        //+ ola ta alla details 

        //public string UserName=FirstName.value+" " +LastName
        
        public ApplicationUser()
        {
            
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       // //Methodos wste na ftiaxnetai automata to username Apo FirstName kai LastName
       //public void SetUserName()
       // {
       //     UserName = FirstName + " " + LastName;
       // }
        
    }

}