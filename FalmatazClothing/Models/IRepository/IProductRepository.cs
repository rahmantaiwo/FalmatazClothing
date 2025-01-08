using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductAsync(Guid id);
    }
}
