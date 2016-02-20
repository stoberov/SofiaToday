using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(SofiaToday.Web.Startup))]

namespace SofiaToday.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
