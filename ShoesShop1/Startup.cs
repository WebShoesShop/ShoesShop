using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoesShop1.Startup))]
namespace ShoesShop1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
