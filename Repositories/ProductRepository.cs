using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Interfaces;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Repositories 
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProducts() 
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        public async Task DeleteProductById(int id) 
        {
            var itemToBeDeleted = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (itemToBeDeleted != null)
                _context.Products.Remove(itemToBeDeleted);

            await SaveChanges();    
        }

        public async Task AddProduct(Product product) 
        {
            await _context.Products.AddAsync(product);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(int id, Product product)
        {
            Product productToBeUpdated = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            
            if (productToBeUpdated != null)
            {
                productToBeUpdated.Name = product.Name;
                productToBeUpdated.Price = product.Price;
                
                await SaveChanges();
            }
            
        }
    }
}