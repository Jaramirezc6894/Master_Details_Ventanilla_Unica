using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Master_Details_Ventanilla_Unica.Startup))]
namespace Master_Details_Ventanilla_Unica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
