using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoStudio.WebApp.Startup))]
namespace PhotoStudio.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
