using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace AutomationTests.Driver
{
    public class BrowserDriver : IBrowserDriver
    {
        public IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public IWebDriver GetFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public IWebDriver GetEdgeDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver();
        }
    }
}

public enum BrowserType
{ 
    Chrome,
    Firefox,
    Edge
}
