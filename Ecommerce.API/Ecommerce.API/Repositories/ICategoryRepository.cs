using Ecommerce.API.Models.Entities;

namespace Ecommerce.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> CreateAsync(Category category);
      

    }
}
