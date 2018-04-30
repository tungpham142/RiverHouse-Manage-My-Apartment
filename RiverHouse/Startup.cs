using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RiverHouse.Startup))]
namespace RiverHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
