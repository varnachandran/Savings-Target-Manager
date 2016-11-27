using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SavingsTarget.Startup))]
namespace SavingsTarget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
