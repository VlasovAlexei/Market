using OpenQA.Selenium;
using TestFramework.Driver;
using TestFramework.Extensions;

namespace TestProject.Pages
{
    public interface IHomePage
    {
        void CreateProduct();

        void PerformClickOnSpecialValue(string name, string operation);
    }

    public class HomePage : IHomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IDriverFixture driverFixture) => driver = driverFixture.Driver;

        IWebElement lnkProduct => driver.FindElement(By.LinkText("Product"));
        IWebElement lnkCreate => driver.FindElement(By.LinkText("Create New"));

        IWebElement tableList => driver.FindElement(By.CssSelector(".table"));

        public void CreateProduct()
        {
            lnkProduct.Click();
            lnkCreate.Click();
        }

        public void PerformClickOnSpecialValue(string name, string operation)
        {
            tableList.PerformActionOnCell("5", "Name", name, operation);
        }
    }
}
