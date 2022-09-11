using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentCG.Startup))]
namespace AssignmentCG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
