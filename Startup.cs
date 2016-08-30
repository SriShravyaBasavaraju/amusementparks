using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmusementParks.Startup))]
namespace AmusementParks
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
