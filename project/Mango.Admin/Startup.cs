using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mango.Admin.Startup))]
namespace Mango.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
