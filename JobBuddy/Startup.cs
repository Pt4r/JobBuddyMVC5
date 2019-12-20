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
        }
    }
}
