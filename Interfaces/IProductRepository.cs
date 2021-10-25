using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Models;

namespace eCommerce.Interfaces 
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task DeleteById(int id);
        Task Add(Product product);
        Task Update(int id, Product product);
        Task SaveChanges();
    }
}