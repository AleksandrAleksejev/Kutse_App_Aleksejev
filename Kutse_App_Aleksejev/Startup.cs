using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kutse_App_Aleksejev.Startup))]
namespace Kutse_App_Aleksejev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
