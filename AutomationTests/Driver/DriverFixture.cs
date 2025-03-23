using AutomationTests.Settings;
using OpenQA.Selenium;

namespace AutomationTests.Driver
{
    public class DriverFixture : IDriverFixture
    {
        IWebDriver driver;
        private readonly TestSettings testSettings;
        private readonly IBrowserDriver browserDriver;

        public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
        {
            this.testSettings = testSettings;
            this.browserDriver = browserDriver;
            driver = GetWebDriver();
        }

        public IWebDriver Driver => driver;

        private IWebDriver GetWebDriver()
        {
            return testSettings.BrowserType switch
            {
                BrowserType.Chrome => browserDriver.GetChromeDriver(),
                BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
                BrowserType.Edge => browserDriver.GetEdgeDriver(),
                _ => browserDriver.GetChromeDriver()
            };
        }
    }
}
