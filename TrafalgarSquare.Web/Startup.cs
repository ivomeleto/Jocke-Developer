using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using TrafalgarSquare.Web.Hubs;

[assembly: OwinStartupAttribute(typeof(TrafalgarSquare.Web.Startup))]
namespace TrafalgarSquare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Add CustomUserIdProvider
            var idProvider = new CustomUserIdProvider();

            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
