using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework.Driver;

namespace TestFramework
{
    public class UnitTest1 : IDisposable
    {
        IWebDriver driver;

        public UnitTest1(IDriverFixture driverFixture)
        {
            driver = driverFixture.Driver;
            driver.Navigate().GoToUrl(new Uri("http://localhost:5001/"));
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void Test1()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Table");
            driver.FindElement(By.Id("Description")).SendKeys("work table");
            driver.FindElement(By.Id("Price")).SendKeys("120");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("2");
            driver.FindElement(By.Id("Create")).Submit();
        }

        [Fact]
        public void Test2()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Desk");
            driver.FindElement(By.Id("Description")).SendKeys("work desk");
            driver.FindElement(By.Id("Price")).SendKeys("120");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("2");
            driver.FindElement(By.Id("Create")).Submit();
        }

        [Fact]
        public void Test3()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Chair");
            driver.FindElement(By.Id("Description")).SendKeys("work chair");
            driver.FindElement(By.Id("Price")).SendKeys("120");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("3");
            driver.FindElement(By.Id("Create")).Submit();
        }
    }
}
