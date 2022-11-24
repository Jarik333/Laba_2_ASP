using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laba_2_ASP.Startup))]
namespace Laba_2_ASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
