using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBSHOP_CKLT.Startup))]
namespace WEBSHOP_CKLT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
