namespace Ecommerce.API.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Foreign keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Relationships
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
