using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoFactory.Startup))]
namespace DoFactory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
