using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinExWebApp20444290.Startup))]
namespace SinExWebApp20444290
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
