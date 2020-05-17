using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyStackOverFlow.Startup))]
namespace MyStackOverFlow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
