using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(initial.Startup))]
namespace initial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
