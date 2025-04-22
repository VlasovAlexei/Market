using OpenQA.Selenium;
using ProductAPI.Data;
using TestFramework.Driver;
using TestFramework.Extensions;

namespace TestProject.Pages
{
    public interface ICreateProductPage
    { 
        void EnterProductDetails(Product product);
    }

    public class CreateProductPage : ICreateProductPage
    {
        private readonly IWebDriver driver;

        public CreateProductPage(IDriverFixture driverFixture) => driver = driverFixture.Driver;

        IWebElement txtName => driver.FindElement(By.Id("Name"));
        IWebElement txtDescription => driver.FindElement(By.Id("Description"));
        IWebElement txtPrice => driver.FindElement(By.Id("Price"));
        IWebElement ddlProductType => driver.FindElement(By.Id("ProductType"));
        IWebElement btnCreate => driver.FindElement(By.Id("Create"));

        public void EnterProductDetails(Product product)
        {
            txtName.ClearAndEnterText(product.Name);
            txtDescription.ClearAndEnterText(product.Description);
            txtPrice.ClearAndEnterText(product.Price.ToString());
            ddlProductType.SelectDropDownByText(product.ProductType.ToString());
            btnCreate.Click();
        }
    }
}
