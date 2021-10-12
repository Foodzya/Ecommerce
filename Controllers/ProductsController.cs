using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Interfaces;

namespace eCommerce.Controllers 
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts() 
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById([FromRoute] int id) 
        {
            return _productService.GetProductById(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProductById([FromRoute] int id) 
        {
            _productService.DeleteProductById(id);
            return NoContent();
        }
        
        [HttpPost]
        public ActionResult AddProduct([FromBody] Product product) 
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (product != null) 
            {
                _productService.UpdateProduct(id, product);

                return Ok();
            }
            else
                return NoContent(); 
                
 
        }
    }
}
