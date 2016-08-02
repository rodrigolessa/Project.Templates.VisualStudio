using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sample.template.vs11.UI.Web.Startup))]
namespace sample.template.vs11.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
