using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
using FalmatazClothing.Models.DTO.Order;

namespace FalmatazClothing.Models.IServices
{
    public interface IOrderService
    {
        Task<BaseResponse<OrderDto>> GetOrderByIdAsync(Guid id);
        Task<BaseResponse<List<OrderDto>>> GetAllOrdersAsync();
        Task<BaseResponse<List<OrderDto>>> GetUserOrdersAsync(string userId);
        Task<BaseResponse<OrderDto>> PlaceOrdersAsync(OrderDto order);
        Task<BaseResponse<Order>> UpdateOrderAsync(Guid orderId, OrderStatus status);
    }
}
 