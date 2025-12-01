
namespace EcommerceAPI.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}
