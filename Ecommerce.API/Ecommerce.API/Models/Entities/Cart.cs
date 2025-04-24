namespace Ecommerce.API.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Foreign key
        public int UserId { get; set; }

        // Relationships
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
