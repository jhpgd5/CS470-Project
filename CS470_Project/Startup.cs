using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS470_Project.Startup))]
namespace CS470_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
