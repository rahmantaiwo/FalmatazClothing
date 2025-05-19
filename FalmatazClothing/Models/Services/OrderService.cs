using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
using FalmatazClothing.Models.DTO.Order;
using FalmatazClothing.Models.DTO.OrderItem;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;

namespace FalmatazClothing.Models.Services
{
    public class OrderService : IOrderService
    {
       private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly ApplicationDbContext _dbContext;
        public OrderService(IOrderRepository orderRepository, ICartService cartService, ApplicationDbContext dbContext)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<List<OrderDto>>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await _orderRepository.GetAllOrdersAsync();
                if (orders != null || !orders.Any())
                {
                    var orderDetails = orders.Select(order => new OrderDto
                    {
                        //Id = order.Id,
                        UserId = order.UserId,
                        OrderDate = DateTime.Now,
                        TotalAmount = order.TotalAmount,
                        Status = order.Status,
                        ShipppingAddress = order.ShipppingAddress,
                        OrderItems = order.orderItems.Select(oi => new OrderItemDto
                        {
                            ProductId = oi.ProductId,
                            Quantity = oi.Quantity,
                            UnitPrice = oi.UnitPrice
                        }).ToList()
                    }).ToList();
                    return new BaseResponse<List<OrderDto>>()
                    {
                        IsSuccessful = true,
                        Message = "Orders retrieved successfully",
                        Data = orderDetails
                    };
                }
                return new BaseResponse<List<OrderDto>>() { IsSuccessful = false, Message = "Orders not found", Data = null };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<OrderDto>>
                {
                    IsSuccessful = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<BaseResponse<OrderDto>> GetOrderByIdAsync(Guid id)
        {
            try
            {
                var order = await _orderRepository.GetOrderByIdAsync(id);
                if (order != null)
                {
                    var orderDetails = new OrderDto
                    {
                        UserId = order.UserId,
                        OrderDate = DateTime.Now,
                        TotalAmount = order.TotalAmount,
                        Status = order.Status,
                        ShipppingAddress = order.ShipppingAddress,
                        OrderItems = order.orderItems.Select(oi => new OrderItemDto
                        {
                            ProductId = oi.ProductId,
                            Quantity = oi.Quantity,
                            UnitPrice = oi.UnitPrice
                        }).ToList()
                    };
                    return new BaseResponse<OrderDto> { IsSuccessful = true, Message = "Order retrieved successful", Data = orderDetails };
                }
                return new BaseResponse<OrderDto> { IsSuccessful = false, Message = "Order not found", Data = null };
            }
            catch (Exception ex) 
            {
                return new BaseResponse<OrderDto>
                {
                    IsSuccessful = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<BaseResponse<List<OrderDto>>> GetUserOrdersAsync(string userId)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
                var orderDtos = orders.Select(order => new OrderDto
                {
                    UserId = order.UserId,
                    OrderDate = DateTime.Now,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status,
                    ShipppingAddress = order.ShipppingAddress,
                    OrderItems = order.orderItems.Select(item => new OrderItemDto
                    {
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                }).ToList();
                return new BaseResponse<List<OrderDto>> { IsSuccessful = true, Message = "Order retrieved Succesfully", Data = orderDtos };
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<OrderDto>>
                {
                    IsSuccessful = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<BaseResponse<OrderDto>> PlaceOrdersAsync(OrderDto order)
        {
            try
            {
                var cart = await _cartService.GetCartByByUserIdAsync(order.UserId);
                if (cart == null || cart.Data.CartItems == null || !cart.Data.CartItems.Any())
                {
                    var newOrder = new Order
                    {
                        UserId = order.UserId,
                        OrderDate = DateTime.Now,
                        TotalAmount = cart.Data.CartItems.Sum(item => item.Quantity * item.Price),
                        ShipppingAddress = order.ShipppingAddress,
                        Status = OrderStatus.Pending,
                        orderItems = cart.Data.CartItems.Select(CartItem => new OrderItem
                        {
                            ProductId = CartItem.ProductId,
                            Quantity = CartItem.Quantity,
                            UnitPrice = CartItem.Price
                        }).ToList()
                    };
                    var createdOrder = await _orderRepository.CreateOrderAsync(newOrder);
                    var orderDto = new OrderDto
                    {
                        UserId = createdOrder.UserId,
                        OrderDate = createdOrder.OrderDate,
                        TotalAmount = createdOrder.TotalAmount,
                        Status = createdOrder.Status,
                        ShipppingAddress = createdOrder.ShipppingAddress,
                        OrderItems = createdOrder.orderItems.Select(OrderItem => new OrderItemDto
                        {
                            ProductId = OrderItem.ProductId,
                            OrderId = OrderItem.OrderId,
                            Quantity = OrderItem.Quantity,
                            UnitPrice = OrderItem.UnitPrice
                        }).ToList()
                    };
                    return new BaseResponse<OrderDto> { IsSuccessful = true, Message = "Order placed successfully", Data = orderDto};
                }
                return new BaseResponse<OrderDto> { IsSuccessful = false, Message = "Order place failed", Data = null };
            }
            catch(Exception ex)
            {
                return new BaseResponse<OrderDto>
                {
                    IsSuccessful = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<BaseResponse<Order>> UpdateOrderAsync(Guid orderId, OrderStatus status)
        {
            try
            {
                var updated = await _orderRepository.UpdateOrderAsync(orderId, status);
                if(updated != null)
                {
                    await _dbContext.SaveChangesAsync();
                    var order = await _orderRepository.GetOrderByIdAsync(orderId);
                    var dto = new OrderDto
                    {
                        UserId = order.UserId,
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                        ShipppingAddress = order.ShipppingAddress,
                        Status = order.Status,
                        OrderItems = order.orderItems.Select(i => new OrderItemDto 
                                                       {
                                                        ProductId = i.ProductId,
                                                        Quantity = i.Quantity,
                                                        UnitPrice = i.UnitPrice,    
                                                       }).ToList()
                    };
                    return new BaseResponse<Order> { IsSuccessful = true, Message = "order updated successfullly", Data = updated };
                }
                return new BaseResponse<Order> { IsSuccessful = false, Message = "Order not found", Data = updated };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>
                {
                    IsSuccessful = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data  = null
                };
            }
        }
    }
}
