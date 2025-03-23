using AutomationTests.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace AutomationTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.UseWebDriverInitializer(BrowserType.Chrome);
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();
        }
    }
}
