using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Models;

namespace eCommerce.Interfaces 
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(int id, Product product);
        Task SaveChangesAsync();
    }
}