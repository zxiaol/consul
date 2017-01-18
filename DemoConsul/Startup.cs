using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoConsul.Startup))]
namespace DemoConsul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
