using Ecommerce.API.Data;
using Ecommerce.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly EcommerceDbContext _context;
        public CategoryRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }


    }
}
