using OpenQA.Selenium;
using ProductAPI.Data;
using TestFramework.Driver;
using TestProject.Pages;

namespace TestProject
{
    public class UnitTest1 : IDisposable
    {
        private readonly IHomePage homePage;
        private readonly ICreateProductPage createProductPage;
        IWebDriver driver;

        public UnitTest1(IDriverFixture driverFixture, IHomePage homePage, ICreateProductPage createProductPage)
        {
            driver = driverFixture.Driver;
            driver.Navigate().GoToUrl(new Uri("http://localhost:5001/"));
            this.homePage = homePage;
            this.createProductPage = createProductPage;
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void Test1()
        {
            homePage.CreateProduct();

            createProductPage.EnterProductDetails(new Product
            {
                Name = "AutoProduct",
                Description = "AutoDescription",
                Price = 444,
                ProductType = ProductType.PERIPHARALS
            });
        }
    }
}
