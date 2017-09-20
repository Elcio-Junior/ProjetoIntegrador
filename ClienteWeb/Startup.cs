using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClienteWeb.Startup))]
namespace ClienteWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
