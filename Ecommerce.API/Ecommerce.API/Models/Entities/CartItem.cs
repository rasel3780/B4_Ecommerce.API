namespace Ecommerce.API.Models.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // Foreign keys
        public int CartId { get; set; }
        public int ProductId { get; set; }

        // Relationships
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
