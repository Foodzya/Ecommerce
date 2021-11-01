using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Interfaces;
using eCommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using eCommerce.Data.Context;

namespace eCommerce.Repositories 
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync() 
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        public async Task DeleteByIdAsync(int id) 
        {
            var itemToBeDeleted = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (itemToBeDeleted != null)
                _context.Products.Remove(itemToBeDeleted);

            await SaveChangesAsync();    
        }

        public async Task AddAsync(Product product) 
        {
            await _context.Products.AddAsync(product);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Product product)
        {
            Product productToBeUpdated = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            
            if (productToBeUpdated != null)
            {
                productToBeUpdated.Name = product.Name;
                productToBeUpdated.Price = product.Price;
                
                await SaveChangesAsync();
            }
            
        }
    }
}