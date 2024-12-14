using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.IRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrder(Guid id);
    }
}
