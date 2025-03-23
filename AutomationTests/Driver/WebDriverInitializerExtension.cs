using AutomationTests.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AutomationTests.Driver;

public static class WebDriverInitializerExtension
{
    public static IServiceCollection UseWebDriverInitializer(
        this IServiceCollection services, 
        BrowserType browserType)
    {
        services.AddSingleton(new TestSettings
        { 
            BrowserType = browserType
        });

        return services;
    }
}
