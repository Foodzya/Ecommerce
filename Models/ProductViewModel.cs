using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models 
{
    public class ProductViewModel 
    {
        // public int Id { get; set; }
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