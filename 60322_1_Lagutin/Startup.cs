using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_60322_1_Lagutin.Startup))]
namespace _60322_1_Lagutin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
