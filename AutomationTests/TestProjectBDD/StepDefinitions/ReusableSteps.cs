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

        [Given("I ensure the following product is created")]
        public void GivenIEnsureTheFollowingProductIsCreated(DataTable dataTable)
        {
            var product = dataTable.CreateInstance<Product>();

            productRepository.AddProduct(product);

            scenarioContext.Set(product);
        }

        [Given("I cleanup following data")]
        public void GivenICleanupFollowingData(DataTable dataTable)
        {
            var products = dataTable.CreateSet<Product>();

            foreach (var product in products)
            {
                var prod = productRepository.GetProductByName(product.Name);

                if (prod != null)
                {
                    productRepository.DeleteProduct(product.Name);
                }
            }
        }
    }
}
