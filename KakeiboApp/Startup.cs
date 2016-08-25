using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KakeiboApp.Startup))]
namespace KakeiboApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
