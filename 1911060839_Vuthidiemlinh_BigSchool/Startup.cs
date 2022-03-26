using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1911060839_Vuthidiemlinh_BigSchool.Startup))]
namespace _1911060839_Vuthidiemlinh_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
