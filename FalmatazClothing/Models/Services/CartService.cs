using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.Cart;
using FalmatazClothing.Models.DTO.CartItem;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FalmatazClothing.Models.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _dbContext;
        public CartService(ICartRepository cartRepository, IProductService productService, ApplicationDbContext dbContext)
        {
            _cartRepository = cartRepository;
            _productService = productService;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<CartDto>> GetCartByByUserIdAsync(string userId)
        {
            try
            {
                var cart = await _dbContext.Carts
                 .Include(c => c.CartItems)
                 .ThenInclude(ci => ci.Product)
                 .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart == null) 
                {
                    cart = new Cart
                    {
                        //UserId = userId,
                        //CreateDate = DateTime.Now
                        Id = Guid.NewGuid(),
                        UserId = userId
                    };
                    //if(string.IsNullOrEmpty(userId))
                    //{
                    //    throw new Exception("UserId cannot be null or empty when creating a cart.");
                    //}
                    _dbContext.Carts.Add(cart);
                    await _dbContext.SaveChangesAsync();
                }

                var response = new CartDto
                {
                    Id = cart.Id,
                    UserId = cart.UserId,
                    CartItems = cart.CartItems.Select(ci => new CartItemDto
                    {
                        Id = ci.Id,
                        ProductId = ci.ProductId,
                        ProductName = ci.Product.Style.ToString(),
                        Quantity = ci.Quantity,
                        Price = ci.Price
                    }).ToList()
                };
                return new BaseResponse<CartDto> { IsSuccessful = true, Message = "Cart successfully retrieved", Data = response };
            }
            catch (Exception ex)
            {
                throw new Exception("Cart not found.");
            }
        }
        private async Task<Cart> GetOrCreateCartAsync(string userId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,

                };
                _dbContext.Carts.Add(cart);
                await _dbContext.SaveChangesAsync();
            }

            return cart;
        }
        public async Task<BaseResponse<CartDto>> AddToCartAsync(AddToCartDto dto)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(dto.ProductId);

                if (product == null || product.StockQuantity <= 0)
                {
                    throw new InvalidOperationException("This product is currently out of stock.");
                }

                var cart = await GetOrCreateCartAsync(dto.UserId);
                var cartItem = await _dbContext.CartItems
                    .SingleOrDefaultAsync(ci => ci.CartId == cart.Id && ci.ProductId == dto.ProductId);

                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        Id = Guid.NewGuid(),
                        CartId = cart.Id,
                        ProductId = dto.ProductId,
                        Quantity = dto.StockQuantity,
                        Price = product.Price,
                    };
                    _dbContext.CartItems.Add(cartItem);
                }
                else
                {
                    if (cartItem.Quantity + dto.StockQuantity > product.StockQuantity)
                    {
                        throw new InvalidOperationException("The quantity exceeds the available stock.");
                    }

                    cartItem.Quantity += dto.StockQuantity;
                }
                await _dbContext.SaveChangesAsync();
                return new BaseResponse<CartDto> { IsSuccessful = true, Message = $"Product added to cart", Data = null };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CartDto> { IsSuccessful = false, Message = $"Error: {ex.Message}", Data = null };
            }
        }



        public async Task<BaseResponse<CartDto>> RemoveFromCartAsync(RemoveFromCartDto dto)
        {
            try
            {
                var cart = await _cartRepository.GetCartByUserIdAsync(dto.UserId.ToString());
                if (cart == null)
                    return new BaseResponse<CartDto> { IsSuccessful = false, Message = "Cart not found", Data = null };

                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == dto.ProductId);
                if (cartItem == null)
                    return new BaseResponse<CartDto> { IsSuccessful = false, Message = "Item not found in cart", Data = null };

                var productResponse = await _productService.GetProduct(dto.ProductId);
                if (productResponse.IsSuccessful && productResponse.Data != null)
                {
                    productResponse.Data.StockQuantity += cartItem.Quantity;
                }

                cart.CartItems.Remove(cartItem);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse<CartDto>
                {
                    IsSuccessful = true,
                    Message = "Item removed from cart successfully",
                    Data = new CartDto
                    {
                        UserId = cart.UserId
                    }
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CartDto> { IsSuccessful = false, Message = $"Error: {ex.Message}", Data = null };
            }
        }

        public async Task<BaseResponse<CartDto>> UpdateCartItemQuantityAsync(UpdateCartItemDto dto)
        {
            try
            {
                var cart = await _cartRepository.GetCartByUserIdAsync(dto.UserId.ToString());
                if (cart != null)
                {
                    var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == dto.ProductId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity = dto.Quantity;
                        await _dbContext.SaveChangesAsync();
                    }
                }
                return new BaseResponse<CartDto> { IsSuccessful = true, Message = "Quantity updated successfully", Data = null };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CartDto> { IsSuccessful = false, Message = $"{ex.Message}", Data = null };
            }
        }
    }
}
