using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class MaterialTypeRepository : IMaterialTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MaterialTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MaterialType>> GetAllMaterialTypeAsync()
        {
            return await _dbContext.MaterialTypes.ToListAsync();
        }

        public async Task<MaterialType?> GetMaterialTypeAsync(Guid id)
        {
            return await _dbContext.MaterialTypes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MaterialType?> GetMaterialTypeByNameAsync(string name)
        {
            return await _dbContext.MaterialTypes.FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}
