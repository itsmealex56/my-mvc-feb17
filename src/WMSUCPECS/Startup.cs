using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WMSUCPECS.Startup))]
namespace WMSUCPECS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
