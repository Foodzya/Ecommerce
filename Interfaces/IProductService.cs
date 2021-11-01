using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Data.Entities;

namespace eCommerce.Interfaces 
{
    public interface IProductService 
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(int id, Product product);
    }
}
