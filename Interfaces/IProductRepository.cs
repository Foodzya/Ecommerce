using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;

namespace eCommerce.Interfaces 
{
    public interface IProductRepository 
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void DeleteProductById(int id);
        void AddProduct(Product product);
    }
}