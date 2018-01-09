using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeminarDva.Startup))]
namespace SeminarDva
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
