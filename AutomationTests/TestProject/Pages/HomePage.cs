using OpenQA.Selenium;
using TestFramework.Driver;

namespace TestProject.Pages
{
    public interface IHomePage
    {
        void CreateProduct();
    }

    public class HomePage : IHomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IDriverFixture driverFixture) => driver = driverFixture.Driver;

        IWebElement lnkProduct => driver.FindElement(By.LinkText("Product"));
        IWebElement lnkCreate => driver.FindElement(By.LinkText("Create New"));

        public void CreateProduct()
        {
            lnkProduct.Click();
            lnkCreate.Click();
        }
    }
}
