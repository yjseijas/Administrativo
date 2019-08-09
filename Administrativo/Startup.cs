using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Administrativo.Startup))]
namespace Administrativo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
