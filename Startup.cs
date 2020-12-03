using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TercerParcial_Centurion.Startup))]
namespace TercerParcial_Centurion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
