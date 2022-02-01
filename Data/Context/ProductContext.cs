using Microsoft.EntityFrameworkCore;
using eCommerce.Data.Entities;

namespace eCommerce.Data.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}