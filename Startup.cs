using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sondeo_web_7eam.Startup))]
namespace Sondeo_web_7eam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
