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
            
            List<Product> listOfProducts = await _productService.GetAll();

            foreach(Product p in listOfProducts) 
            {
                listOfProductViewModels.Add(new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                });
            }

            return listOfProductViewModels;            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById([FromRoute] int id) 
        {
            var GetProductByIdTask = await _productService.GetById(id);

            ProductViewModel viewModel = new ProductViewModel()
            {
                Id = GetProductByIdTask.Id,
                Name = GetProductByIdTask.Name,
                Price = GetProductByIdTask.Price
            };

            return viewModel;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductById([FromRoute] int id) 
        {
            await _productService.DeleteById(id);
            
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product) 
        {
                await _productService.Add(product);
                
                return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
                await _productService.Update(id, product);

                return Ok();
        }
    }
}
