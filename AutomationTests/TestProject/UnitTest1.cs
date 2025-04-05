using AutoFixture.Xunit2;
using ProductAPI.Data;
using TestProject.Pages;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly IHomePage homePage;
        private readonly ICreateProductPage createProductPage;

        public UnitTest1(IHomePage homePage, ICreateProductPage createProductPage)
        {

            this.homePage = homePage;
            this.createProductPage = createProductPage;
        }

        [Theory, AutoData]
        public void Test1(Product product)
        {
            homePage.CreateProduct();

            createProductPage.EnterProductDetails(product);
        }

        [Theory, AutoData]
        public void Test2(Product product)
        {
            homePage.CreateProduct();

            createProductPage.EnterProductDetails(product);

            homePage.PerformClickOnSpecialValue(product.Name, "Details");
        }
    }
}
