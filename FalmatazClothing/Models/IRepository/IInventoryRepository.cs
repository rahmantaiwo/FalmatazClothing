using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.IRepository
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetAllInventoryAsync();
        Task<Inventory> GetInventoryAsync(Guid id);
    }
}
