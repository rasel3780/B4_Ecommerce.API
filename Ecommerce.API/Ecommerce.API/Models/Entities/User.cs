using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
