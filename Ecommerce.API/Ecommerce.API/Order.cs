using Ecommerce.API.Models.Entities;

namespace Ecommerce.API
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Processing, Shipped, Delivered, Cancelled
        public string ShippingAddress { get; set; }

        // Foreign key
        public int UserId { get; set; }

        // Relationships
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
