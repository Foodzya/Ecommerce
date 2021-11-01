using System.ComponentModel.DataAnnotations;
using eCommerce.Data.Entities;

namespace eCommerce.ControllerModels
{
    public class ProductInputModel 
    {
        [Required(ErrorMessage = "Name of a product is required")]
        public string Name { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        public static Product MapToProduct(ProductInputModel inputModel)
        {
            Product product = new Product()
            {
                Name = inputModel.Name,
                Price = inputModel.Price
            };

            return product;
        }
    }
}