using TestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace TestFramework.Extensions;

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
