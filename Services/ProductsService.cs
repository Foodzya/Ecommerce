using System.Collections.Generic;
using eCommerce.Models;
using eCommerce.Interfaces;
using System.Threading.Tasks;

namespace eCommerce.Services 
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(Product product)
        {
            await _productRepository.AddProduct(product);
        }

        public async Task DeleteProductById(int id)
        {
            await _productRepository.DeleteProductById(id);
        }

        public async Task<List<Product>> GetAllProducts() => await _productRepository.GetAllProducts();

        public async Task<Product> GetProductById(int id) => await _productRepository.GetProductById(id);

        public async Task UpdateProduct(int id, Product product)
        {
            await _productRepository.UpdateProduct(id, product);
        }
    }
}