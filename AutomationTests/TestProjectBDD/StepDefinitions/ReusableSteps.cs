using ProductAPI.Repository;

namespace TestProjectBDD.StepDefinitions
{
    [Binding]
    public class ReusableSteps
    {
        private readonly ScenarioContext scenarioContext;

        private readonly IProductRepository productRepository;

        public ReusableSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
        {
            this.scenarioContext = scenarioContext;
            this.productRepository = productRepository;
        }

        [When("I delete product (.*) for cleanup")]
        public void ThenIDeleteProductHeadphonesForCleanup(string productName)
        {
            productRepository.DeleteProduct(productName);
        }

    }
}
