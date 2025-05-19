using FalmatazClothing.Models.DTO.Cart;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Carts()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var response = await _cartService.GetCartByByUserIdAsync(userId);

            int itemCount = response.Data?.CartItems.Sum(ci => ci.Quantity) ?? 0;
            ViewData["CartCount"] = itemCount;

            return View("Carts", response.Data ?? new CartDto());
        }

        //Add to cart
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var dto = new AddToCartDto
            {
                UserId = userId,
                ProductId = productId,
                StockQuantity = quantity
            };

            var response = await _cartService.AddToCartAsync(dto);
            if (response.IsSuccessful)
            {
                //return Ok("Item added to cart!");
                return RedirectToAction("Carts", await _cartService.GetCartByByUserIdAsync(userId));
            }
            //return BadRequest(response.Message);
            return RedirectToAction("Store", "Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(Guid productId, int quantity)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var dto = new UpdateCartItemDto
            {
                UserId = Guid.Parse(userId),
                ProductId = productId,
                Quantity = quantity
            };

            await _cartService.UpdateCartItemQuantityAsync(dto);

            var updatedCart = await _cartService.GetCartByByUserIdAsync(userId);
            return PartialView("_CartPartial", updatedCart.Data);
        }


        //Remove from Cart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var dto = new RemoveFromCartDto
            {
                UserId = userId,
                ProductId = productId
            };

            var response = await _cartService.RemoveFromCartAsync(dto);

            //await _cartService.RemoveFromCartAsync(dto);
            if (response.IsSuccessful)
            {
                var updatedCart = await _cartService.GetCartByByUserIdAsync(userId);
                return PartialView("_CartPartial", updatedCart.Data);
            }
            return BadRequest("Failed to remove item from cart.");
        }
    }
}