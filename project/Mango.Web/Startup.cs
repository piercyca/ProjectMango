using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mango.Web.Startup))]
namespace Mango.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
