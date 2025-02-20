using FalmatazClothing.Entities;
using FalmatazClothing.Enum;

namespace FalmatazClothing.Models.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<Product?> GetProductTypeByNameAsync(ProductStyles style);
    }
}
