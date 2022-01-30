using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aplikacija1.Startup))]
namespace aplikacija1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
