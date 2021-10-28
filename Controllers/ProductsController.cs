using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using eCommerce.Interfaces;
using System.Threading.Tasks;

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
            List<ProductViewModel> listOfProductViewModels = new List<ProductViewModel>();
            ProductViewModel viewModel;

            List<Product> listOfProducts = await _productService.GetAllAsync();            

            foreach(Product p in listOfProducts) 
            {
                viewModel = ProductViewModel.MapFromProduct(p);

                listOfProductViewModels.Add(viewModel);
            }

            return Ok(listOfProductViewModels);            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById([FromRoute] int id) 
        {
            var ProductById = await _productService.GetByIdAsync(id);

            ProductViewModel viewModel;

            viewModel = ProductViewModel.MapFromProduct(ProductById);

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
