﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using TestFramework.Settings;

namespace TestFramework.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        IWebDriver driver;
        private readonly TestSettings testSettings;
        private readonly IBrowserDriver browserDriver;

        public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
        {
            this.testSettings = testSettings;
            this.browserDriver = browserDriver;
            if(testSettings.ExecutionType == ExecutionType.Local)
                driver = GetWebDriver();
            else 
                driver = new RemoteWebDriver(testSettings.SeleniumGridUrl, GetBrowserOptions());
            driver.Navigate().GoToUrl(testSettings.ApplicationUrl);
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

        private dynamic GetBrowserOptions()
        {
            switch (testSettings.BrowserType)
            {
                case BrowserType.Firefox:
                    {
                        var firefoxOption = new FirefoxOptions();
                        firefoxOption.AddAdditionalOption("se:recordVideo", true);
                        return firefoxOption;
                    }
                case BrowserType.Edge:
                    return new EdgeOptions();
                case BrowserType.Safari:
                    return new SafariOptions();
                case BrowserType.Chrome:
                    {
                        var chromeOption = new ChromeOptions();
                        chromeOption.AddAdditionalOption("se:recordVideo", true);
                        return chromeOption;
                    }
                default:
                    return new ChromeOptions();
            }
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
