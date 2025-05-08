using Ecommerce.API.Models.Entities;    

namespace Ecommerce.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> Update(int id, Product product);
        Task<bool> DeleteAsync(int id);


    }
}
