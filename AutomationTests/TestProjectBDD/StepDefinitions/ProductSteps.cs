using TestFramework.Pages;

namespace TestProjectBDD.StepDefinitions;

[Binding]
public sealed class ProductSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IHomePage _homePage;
    private readonly IProductPage _productPage;

    public ProductSteps(ScenarioContext scenarioContext, IHomePage homePage, IProductPage productPage) 
    {
        _scenarioContext = scenarioContext;
        _homePage = homePage;
        _productPage = productPage;
    }

    [Given("I click the Product menu")]
    public void GivenIClickTheProductMenu()
    {
        _homePage.ClickProduct();
    }

    [Given("I click the {string} link")]
    public void GivenIClickTheLink(string create)
    {
        _homePage.ClickCreate();
    }

    [When("I create product with following details")]
    public void GivenICreateProductWithFollowingDetails(DataTable dataTable)
    {
        var product = dataTable.CreateInstance<Product>();

        _productPage.EnterProductDetails(product);

        _scenarioContext.Set(product);
    }

    [When("I click the (.*) link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct(string operation)
    {
        var product = _scenarioContext.Get<Product>();
        _homePage.PerformClickOnSpecialValue(product.Name, operation);
    }

    [Then("I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
        var product = _scenarioContext.Get<Product>();

        var actualProduct = _productPage.GetProductDetails();

        actualProduct
            .Should()
            .BeEquivalentTo(product, option => option.Excluding(x => x.Id));
    }

    [When("I Edit the product details with following")]
    public void WhenIEditTheProductDetailsWithFollowing(DataTable dataTable)
    {
        var product = dataTable.CreateInstance<Product>();

        _productPage.EditProduct(product);

        _scenarioContext.Set(product);
    }
}
