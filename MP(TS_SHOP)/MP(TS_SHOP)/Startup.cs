using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MP_TS_SHOP_.Startup))]
namespace MP_TS_SHOP_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
