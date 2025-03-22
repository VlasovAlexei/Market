using OpenQA.Selenium;
using AutomationTests.Driver;

namespace AutomationTests
{
    public class DriverFixture : IDisposable
    {
        IWebDriver driver;

        public DriverFixture(BrowserType browserType)
        {
            driver = GetWebDriver(browserType);
        }

        public IWebDriver Driver => driver;

        private IWebDriver GetWebDriver(BrowserType browserType)
        { 
            BrowserDriver driver = new BrowserDriver();
            return browserType switch
            {
                BrowserType.Chrome => driver.GetChromeDriver(),
                BrowserType.Firefox => driver.GetFirefoxDriver(),
                BrowserType.Edge => driver.GetEdgeDriver(),
                _ => driver.GetChromeDriver()
            };
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
