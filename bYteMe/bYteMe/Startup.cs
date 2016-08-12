using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bYteMe.Startup))]
namespace bYteMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
