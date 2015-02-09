using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mango.Store.Startup))]
namespace Mango.Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
