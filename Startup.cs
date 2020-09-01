using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caviris_MIS4200.Startup))]
namespace Caviris_MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
