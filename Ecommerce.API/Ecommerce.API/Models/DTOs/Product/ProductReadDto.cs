using Ecommerce.API.Models.DTOs.Category;

namespace Ecommerce.API.Models.DTOs.Product
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //public List<CategoryReadDto> Categories { get; set; } = new List<CategoryReadDto>();
    }
}
