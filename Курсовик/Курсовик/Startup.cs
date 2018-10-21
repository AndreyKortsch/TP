using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Курсовик.Startup))]
namespace Курсовик
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
