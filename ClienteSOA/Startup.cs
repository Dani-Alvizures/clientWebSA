using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClienteSOA.Startup))]
namespace ClienteSOA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
