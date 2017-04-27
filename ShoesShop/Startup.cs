using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoesShop.Startup))]
namespace ShoesShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
