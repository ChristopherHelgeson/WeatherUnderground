using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeatherUndergroundAPI.Startup))]
namespace WeatherUndergroundAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
