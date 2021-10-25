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

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task DeleteById(int id)
        {
            await _productRepository.DeleteById(id);
        }

        public async Task<List<Product>> GetAll() => await _productRepository.GetAll();

        public async Task<Product> GetById(int id) => await _productRepository.GetById(id);

        public async Task Update(int id, Product product)
        {
            await _productRepository.Update(id, product);
        }
    }
}