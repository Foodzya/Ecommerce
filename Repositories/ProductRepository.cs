using System.Collections.Generic;
using System.Linq;
using eCommerce.Interfaces;
using eCommerce.Models;

namespace eCommerce.Repositories 
{
    public class ProductRepository : IProductRepository 
    {
        private readonly List<Product> allProducts;

        public ProductRepository()
        {
            allProducts = new List<Product> 
            {
            new Product { Id = 1, Name = "Crisps", Price = 35 },
            new Product { Id = 2, Name = "Coke", Price = 25 },
            new Product { Id = 3, Name = "Juice", Price = 30 },
            new Product { Id = 4, Name = "Tea", Price = 45 }
            };
        }
        public List<Product> GetAllProducts() 
        {
            return allProducts;
        }

        public Product GetProductById(int id) => allProducts.FirstOrDefault(p => p.Id == id);
        public void DeleteProductById(int id) 
        {
            var itemToBeDeleted = allProducts.FirstOrDefault(p => p.Id == id);
            if (itemToBeDeleted != null)
                allProducts.Remove(itemToBeDeleted);
        }

        public void AddProduct(Product product) 
        {
            allProducts.Add(product);
        }
    }
}