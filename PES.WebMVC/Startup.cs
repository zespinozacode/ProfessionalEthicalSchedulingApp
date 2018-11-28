using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PES.WebMVC.Startup))]
namespace PES.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
