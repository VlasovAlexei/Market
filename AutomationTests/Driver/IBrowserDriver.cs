using OpenQA.Selenium;

namespace AutomationTests.Driver;

public interface IBrowserDriver
{
    IWebDriver GetChromeDriver();
    IWebDriver GetEdgeDriver();
    IWebDriver GetFirefoxDriver();
}
