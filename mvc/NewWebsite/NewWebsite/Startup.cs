using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewWebsite.Startup))]
namespace NewWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
