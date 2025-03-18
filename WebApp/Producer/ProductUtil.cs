namespace WebApp.Producer
{
    public class ProductUtil : IProductUtil
    {
        private readonly ProductAPI _productApiClient;

        public ProductUtil() => _productApiClient = new ProductAPI("http://productapi:8001", new HttpClient());

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productApiClient.CreateAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productApiClient.DeleteProductAsync(id);
        }

        public async Task<Product> EditProduct(Product product)
        {
            return await _productApiClient.UpdateAsync(product);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _productApiClient.GetProductsAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _productApiClient.GetProductByIdAsync(Id);
        }
    }
}
