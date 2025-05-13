using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        public string? Description { get; set; }

        // Relationships
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
