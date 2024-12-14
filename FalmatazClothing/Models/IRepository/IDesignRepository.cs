using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.IRepository
{
    public interface IDesignRepository
    {
        Task<List<Design>> GetAllDesignAsync();
        Task<Design> GetDesignAsync(Guid id);
    }
}
