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

        public async Task<MaterialType> GetMaterialTypeAsync(Guid id)
        {
            return await _dbContext.MaterialTypes.Where(x => x.Id == id).FirstOrDefaultAsync(); 
        }
    }
}
