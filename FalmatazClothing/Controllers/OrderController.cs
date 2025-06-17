using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
using FalmatazClothing.Models;
using FalmatazClothing.Models.DTO.Order;
using FalmatazClothing.Models.DTO.OrderItem;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FalmatazClothing.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService, ICartService cartService, IUserService userService)
        {
            _orderService = orderService;
            _cartService = cartService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _orderService.GetAllOrdersAsync();
            if(!response.IsSuccessful)
            {
                return RedirectToAction("Error", "Home");
            }
            return View("Index",response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> OrderConfirmationAsync(Guid id)
        {
            var orderResponse = await _orderService.GetOrderByIdAsync(id);
            if(!orderResponse.IsSuccessful)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(orderResponse.Data.ToString());
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var cartResponse = await _cartService.GetCartByByUserIdAsync(userId);
            if (!cartResponse.IsSuccessful || cartResponse.Data == null || !cartResponse.Data.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var checkOutViewModel = new CheckoutViewModel
            {
                Cart = cartResponse.Data,
                ShippingAddress = string.Empty,
            };
            return View(checkOutViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cartResponse = await _cartService.GetCartByByUserIdAsync(userId);

                model.Cart =cartResponse.Data;
                model.UserId = userId;

                return View("Checkout", model);
            }

            var userIdFromClaims = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userIdFromClaims != model.UserId)
            {
                return Unauthorized(model.UserId);
            }

            var order = new OrderDto
            {
                UserId = model.UserId,
                ShipppingAddress = model.ShippingAddress,
                OrderItems = model.Cart.CartItems.Select(ci => new OrderItemDto
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Price,
                }).ToList(),
                TotalAmount = model.Cart.CartItems.Sum(ci => ci.Quantity * ci.Price),
                OrderDate = DateTime.Now,
            };

            var result = await _orderService.PlaceOrdersAsync(order);

            if(!result.IsSuccessful)
            {
                ModelState.AddModelError("",result.Message);
                return View("Checkout", model);
            }
            return RedirectToAction("Index", "Store");
        }
        [HttpPost]
        public async Task<IActionResult> ManageOrdersAsync(Guid OrderId, OrderStatus status) 
        {
            var response = await _orderService.UpdateOrderAsync(OrderId, status);
            if(!response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }
            return View("OrderConfirmation");
        }
    }
}
