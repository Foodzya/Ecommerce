using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Interfaces;

namespace eCommerce.Services 
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void DeleteProductById(int id)
        {
            _productRepository.DeleteProductById(id);
        }

        public List<Product> GetAllProducts() => _productRepository.GetAllProducts();

        public Product GetProductById(int id) => _productRepository.GetProductById(id);
    }
}