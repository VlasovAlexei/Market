using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductAPI;

namespace IntegrationTests;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
{
    public WebApplicationFactory<Program> webApplicationFactory;

    public UnitTest1(WebApplicationFactory<Program> webApplicationFactory)
    {
        this.webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task TestWithWebAppFactory()
    {
        var webClient = webApplicationFactory.CreateClient();

        var product = await webClient.GetAsync("/Product/GetProducts");

        var result = product.Content.ReadAsStringAsync().Result;

        result.Should().Contain("Keyboard");
    }

    [Fact]
    public async Task TestWithGeneratedCode()
    {
        var webClient = webApplicationFactory.CreateClient();

        var product = new IntegrationTest.ProductAPI("https://localhost:44334/", webClient);

        var results = await product.GetProductsAsync();

        results.Select(x => x.Name == "Keyboard").Should().NotBeEmpty();
    }
}
