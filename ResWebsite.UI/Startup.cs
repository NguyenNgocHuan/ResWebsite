using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResWebsite.UI.Startup))]
namespace ResWebsite.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
