using eCommerce.Data.Entities;

namespace eCommerce.Controllers.Models
{
    public class ProductViewModel 
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public static ProductViewModel MapFromProduct(Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel() 
            {
                Price = product.Price,
                Name = product.Name
            };

            return productViewModel;
        }
    }
}