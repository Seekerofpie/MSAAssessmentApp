using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSAAssessmentApp.Startup))]

namespace MSAAssessmentApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
