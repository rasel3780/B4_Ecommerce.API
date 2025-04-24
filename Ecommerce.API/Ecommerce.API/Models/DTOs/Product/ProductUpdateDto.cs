using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models.DTOs.Product
{
    public class ProductUpdateDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
