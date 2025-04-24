using Ecommerce.API.Data;
using Ecommerce.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;
        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Models.Entities.Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Product> Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
