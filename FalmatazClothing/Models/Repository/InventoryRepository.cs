using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Inventory>> GetAllInventoryAsync()
        {
            return await _dbContext.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryAsync(Guid id)
        {
            return await _dbContext.Inventories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
