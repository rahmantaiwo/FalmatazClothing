using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.Include(o => o.orderItems).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _dbContext.Orders.Include(o => o.orderItems).FirstOrDefaultAsync(o => o.Id == orderId);
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _dbContext.Orders.Include(o => o.orderItems).Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Guid orderId, OrderStatus status)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order == null) return order;

            order.Status = status;
            return order;
        }
    }     
}

