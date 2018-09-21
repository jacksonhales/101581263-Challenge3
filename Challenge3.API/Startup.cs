using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenge3.API.Startup))]
namespace Challenge3.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
