using AutoFixture.Xunit2;
using FluentAssertions;
using ProductAPI.Data;
using TestProject.Pages;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly IHomePage homePage;
        private readonly IProductPage productPage;

        public UnitTest1(IHomePage homePage, IProductPage createProductPage)
        {

            this.homePage = homePage;
            this.productPage = createProductPage;
        }

        [Theory, AutoData]
        public void Test1(Product product)
        {
            homePage.CreateProduct();

            productPage.EnterProductDetails(product);
        }

        [Theory, AutoData]
        public void Test2(Product product)
        {
            homePage.CreateProduct();

            productPage.EnterProductDetails(product);

            homePage.PerformClickOnSpecialValue(product.Name, "Details");

            var actualProduct = productPage.GetProductDetails();

            actualProduct
                .Should()
                .BeEquivalentTo(product, option => option.Excluding(x => x.Id));
        }
    }
}
