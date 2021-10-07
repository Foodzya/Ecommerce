using System.Collections.Generic;
using eCommerce.Models;

namespace eCommerce.Interfaces 
{
    public interface IProductRepository 
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void DeleteProductById(int id);
        void AddProduct(Product product);
        void SaveChanges();
    }
}