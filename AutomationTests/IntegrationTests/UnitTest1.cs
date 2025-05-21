using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

public class UnitTest1 : IClassFixture<WebApplicationFactory<ProductAPI.Program>>
{
    public WebApplicationFactory<ProductAPI.Program> webApplicationFactory;

    public UnitTest1(WebApplicationFactory<ProductAPI.Program> webApplicationFactory)
    {
        this.webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public void Test1()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5000/");

        var response = client.Send(new HttpRequestMessage(HttpMethod.Get, "Product/GetProducts"));

        //response.Content.ReadAsStringAsync().Result;

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestWithWebAppFactory()
    {
        var webClient = webApplicationFactory.CreateClient();

        var product = await webClient.GetAsync("/Product/GetProducts");

        var result = product.Content.ReadAsStringAsync().Result;

        result.Should().Contain("Keyboard");
    }
}
