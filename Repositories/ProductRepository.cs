using System.Collections.Generic;
using System.Linq;
using eCommerce.Interfaces;
using eCommerce.Models;

namespace eCommerce.Repositories 
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts() 
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id) => _context.Products.FirstOrDefault(p => p.Id == id);
        public void DeleteProductById(int id) 
        {
            var itemToBeDeleted = _context.Products.FirstOrDefault(p => p.Id == id);
            if (itemToBeDeleted != null)
                _context.Products.Remove(itemToBeDeleted);

            SaveChanges();    
        }

        public void AddProduct(Product product) 
        {
            _context.Products.Add(product);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(int id, Product product)
        {
            Product productToBeUpdated = _context.Products.FirstOrDefault(product => product.Id == id);
            
            if (productToBeUpdated != null)
            {
                productToBeUpdated.Name = product.Name;
                productToBeUpdated.Price = product.Price;
                
                SaveChanges();
            }
            
        }
    }
}