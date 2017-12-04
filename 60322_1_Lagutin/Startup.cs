using Microsoft.Owin;
using Owin;
using _60322_1_Lagutin;

[assembly: OwinStartup(typeof(Startup))]
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
