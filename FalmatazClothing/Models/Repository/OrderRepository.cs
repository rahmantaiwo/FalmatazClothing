using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository;
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public Task<Order> GetOrder(Guid id)
    {
        return _dbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}

