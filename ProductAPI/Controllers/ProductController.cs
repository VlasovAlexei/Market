using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Repository;
using System.Collections.Generic;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult<List<Product>> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public Product Create(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        [HttpPut]
        [Route("/[controller]/[action]")]
        public Product Update(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        [HttpDelete]
        [Route("/[controller]/[action]")]
        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
