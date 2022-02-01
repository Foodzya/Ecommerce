using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Controllers.Models;
using eCommerce.Data.Entities;
using eCommerce.Services.Interfaces;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<ActionResult<List<ProductViewModel>>> GetAllProducts() 
        {
            List<Product> listOfProducts = await _productService.GetAllAsync();

            var productViewModels = listOfProducts.Select(p => ProductViewModel.MapFromProduct(p));

            return Ok(productViewModels);  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById([FromRoute] int id) 
        {
            var productById = await _productService.GetByIdAsync(id);

            ProductViewModel viewModel = ProductViewModel.MapFromProduct(productById);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductById([FromRoute] int id) 
        {
            await _productService.DeleteByIdAsync(id);
            
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductInputModel inputModel) 
        {
                Product product = ProductInputModel.MapToProduct(inputModel);

                await _productService.AddAsync(product);
                
                return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductInputModel inputModel)
        {
                Product product = ProductInputModel.MapToProduct(inputModel);

                await _productService.UpdateAsync(id, product);

                return Ok();
        }
    }
}
