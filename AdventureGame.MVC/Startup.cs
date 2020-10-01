using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdventureGame.MVC.Startup))]
namespace AdventureGame.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
