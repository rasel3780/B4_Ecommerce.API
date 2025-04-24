using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        // Relationships
        //public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        //public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        //public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
