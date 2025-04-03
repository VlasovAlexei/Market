using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestFramework.Driver;
using TestFramework.Extensions;
using TestProject.Pages;

namespace TestProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var browserType = config.GetSection("BrowserType").Value;

            services.UseWebDriverInitializer(Enum.Parse<BrowserType>(browserType));
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ICreateProductPage, CreateProductPage>();
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();
        }
    }
}
