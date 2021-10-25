using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Models;

namespace eCommerce.Interfaces 
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task DeleteProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task SaveChanges();
    }
}