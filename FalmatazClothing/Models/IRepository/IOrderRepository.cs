using FalmatazClothing.Entities;
using FalmatazClothing.Enum;

namespace FalmatazClothing.Models.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(Guid orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Guid orderId, OrderStatus status);
    }
}
