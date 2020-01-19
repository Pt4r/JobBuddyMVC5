using JobBuddy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobBuddy.Startup))]
namespace JobBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        //Βημα 1 --> στην αρχη του Application δημιουργω τα roles με την CreateRoles. Αν υπάρχουν ήδη δεν θα ξαναδημιουργηθουν
        //-->if(rolemanager.rolexists("admin").το χρησιμοποιω ώστε να μην περάσουν dublicates στο UserRoles table.
        //τέλος περνάω την CreateRoles μέσα στην Configuration method ώστε να δημιουργηθούν αυτόματα όταν τρέξει το πρόγραμμα.
        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                //create Admin super default user                  

                var user = new ApplicationUser();
                user.FirstName = "Head";
                user.LastName = "Admin";
                user.Email = "HeadAdmin@gmail.com";
                user.UserRole = "Admin";
                user.UserName = user.Email;
                string userPassword = "Test123!";

                var createUser = UserManager.Create(user, userPassword);

                //Add default User to Role Admin    
                if (createUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }

            }

            if (!roleManager.RoleExists("HR"))
            {
                var role = new IdentityRole();
                role.Name = "HR";
                roleManager.Create(role);


            }

            if (!roleManager.RoleExists("Client"))
            {
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);


            }

            if (!roleManager.RoleExists("Mentor"))
            {
                var role = new IdentityRole();
                role.Name = "Mentor";
                roleManager.Create(role);


            }
        }
    }
}
