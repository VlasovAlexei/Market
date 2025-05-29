using FluentAssertions;
using IntegrationTests.Library;
using ProductAPI;

namespace IntegrationTests
{
    public class CustomUnitTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> customWebApplicationFactory;

        public CustomUnitTest(CustomWebApplicationFactory<Program> customWebApplicationFactory)
        {
            this.customWebApplicationFactory = customWebApplicationFactory;
        }

        [Fact]
        public async Task TestCustomWebApplication()
        {
            var webClient = customWebApplicationFactory.CreateDefaultClient();

            var product = new IntegrationTest.ProductAPI("https://localhost:44334/", webClient);

            var results = await product.GetProductsAsync();

            results.Select(x => x.Name == "Keyboard").Should().NotBeEmpty();
        }
    }
}
