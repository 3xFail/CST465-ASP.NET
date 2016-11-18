using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.Net_Project.Startup))]
namespace ASP.Net_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}