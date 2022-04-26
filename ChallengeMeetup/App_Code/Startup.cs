using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengeMeetup.Startup))]
namespace ChallengeMeetup
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
