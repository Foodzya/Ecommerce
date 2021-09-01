using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Services;
using eCommerce.Repositories;

namespace eCommerce.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase 
    {
        
        ProductsService productsService = new ProductsService(new ProductRepository());
        
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts() 
        {
            return productsService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById([FromRoute] int id) 
        {
            return productsService.GetProductById(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProductById([FromRoute] int id) 
        {
            productsService.DeleteProductById(id);
            return NoContent();
        }
        
        [HttpPost]
        public ActionResult AddProduct(Product product) 
        {
            productsService.AddProduct(product);
            return Ok();
        }
    }
}
