using Allure.Xunit.Attributes;
using AutoFixture.Xunit2;
using FluentAssertions;
using ProductAPI.Data;
using TestFramework.Pages;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;

        public UnitTest1(IHomePage homePage, IProductPage createProductPage)
        {

            _homePage = homePage;
            _productPage = createProductPage;
        }   

        [AllureSuite("Basic Suite")]
        [AllureFeature("Test 1")]
        [AllureStory("Story 1")]
        [Theory, AutoData]
        public void Test1(Product product)
        {
            _homePage.ClickProduct();

            _homePage.ClickCreate();

            _productPage.EnterProductDetails(product);
        }

        [AllureSuite("Basic Suite")]
        [AllureFeature("Test 2")]
        [AllureStory("Story 2")]
        [Theory, AutoData]
        public void Test2(Product product)
        {
            _homePage.ClickProduct();

            _homePage.ClickCreate();

            _productPage.EnterProductDetails(product);

            _homePage.PerformClickOnSpecialValue(product.Name, "Details");

            var actualProduct = _productPage.GetProductDetails();

            actualProduct
                .Should()
                .BeEquivalentTo(product, option => option.Excluding(x => x.Id));
        }
    }
}
