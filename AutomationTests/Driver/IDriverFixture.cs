using OpenQA.Selenium;

namespace AutomationTests.Driver;

public interface IDriverFixture
{
    IWebDriver Driver { get; }
}
