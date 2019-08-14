using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QrCodeDemo.Startup))]
namespace QrCodeDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
