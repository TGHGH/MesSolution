using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMes.Startup))]
namespace WebMes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
