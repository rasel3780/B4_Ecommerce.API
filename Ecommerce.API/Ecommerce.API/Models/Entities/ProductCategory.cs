﻿namespace Ecommerce.API.Models.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
