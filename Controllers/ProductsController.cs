using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Services;
using eCommerce.Repositories;
using eCommerce.Interfaces;

namespace eCommerce.Controllers 
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase 
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts() 
        {
            return _service.GetAllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById([FromRoute] int id) 
        {
            return _service.GetProductById(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProductById([FromRoute] int id) 
        {
            _service.DeleteProductById(id);
            return NoContent();
        }
        
        [HttpPost]
        public ActionResult AddProduct([FromBody] Product product) 
        {
            _service.AddProduct(product);
            return Ok();
        }
    }
}
