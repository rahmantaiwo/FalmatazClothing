using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class DesignRepository : IDesignRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DesignRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Design>> GetAllDesignAsync()
        {
            return await _dbContext.Designs.ToListAsync();
        }

        public async Task<Design> GetDesignAsync(Guid id)
        {
            return await _dbContext.Designs.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
