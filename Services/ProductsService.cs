using System.Collections.Generic;
using eCommerce.Data.Entities;
using eCommerce.Repositories.Interfaces;
using eCommerce.Services.Interfaces;
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

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _productRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Product>> GetAllAsync() => await _productRepository.GetAllAsync();

        public async Task<Product> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id);

        public async Task UpdateAsync(int id, Product product)
        {
            await _productRepository.UpdateAsync(id, product);
        }
    }
}