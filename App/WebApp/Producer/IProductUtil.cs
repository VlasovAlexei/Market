﻿
namespace WebApp.Producer
{
    public interface IProductUtil
    {
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product> EditProduct(Product product);
        Task<ICollection<Product>> GetProducts();
        Task<Product> GetProductById(int Id);
    }
}