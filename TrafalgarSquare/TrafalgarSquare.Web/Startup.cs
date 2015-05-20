using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrafalgarSquare.Web.Startup))]
namespace TrafalgarSquare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
