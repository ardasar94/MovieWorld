using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieWorld.Startup))]
namespace MovieWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
