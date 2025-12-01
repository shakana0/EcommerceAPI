
namespace EcommerceAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);

        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();

        Task UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);
    }
}
