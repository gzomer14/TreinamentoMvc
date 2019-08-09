using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NW.CursoMvc.UI.Site.Startup))]
namespace NW.CursoMvc.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
