using FalmatazClothing.Entities;
using FalmatazClothing.Models;

namespace FalmatazClothing.Models.IRepository
{
    public interface IMaterialTypeRepository
    {
        Task<List<MaterialType>> GetAllMaterialTypeAsync();
        Task<MaterialType> GetMaterialTypeAsync(Guid id);
    }
}
