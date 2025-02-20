using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.CartItem;
using FalmatazClothing.Models.DTO.Product;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FalmatazClothing.Models.Services
{
    public class CartItemService : ICarItemService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductService _productService;
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemService(ApplicationDbContext dbContext, IProductService productService, ICartItemRepository cartItemRepository)
        {
            _dbContext = dbContext;
            _productService = productService;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<BaseResponse<bool>> CreateCartItem(CreateCartItemDto request)
        {
            try
            {
                var cartItem = new CartItem()
                {
                    ProductId = request.ProductId,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    TotalPrice = request.Price * request.Quantity,
                };
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Product item added to cart succesfully", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "Product item not added", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = false};
            }
        }

        public async Task<BaseResponse<bool>> DeleteCartItem(Guid id)
        {
            try
            {
                var cartItem = await _cartItemRepository.GetCartItemAsync(id);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Product item removed from cart", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "Product Item not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<List<CartItemDto>>> GetAllCartItems()
        {
            try
            {
                var cartItem = await _cartItemRepository.GetAllCartItemAsync();
                if (cartItem.Count > 0)
                {
                    var items = cartItem.Select(c => new CartItemDto
                    {
                        Id = c.Id,
                        ProductId = c.ProductId,
                        Price = c.Price,
                        TotalPrice = c.TotalPrice,
                        Quantity = c.Quantity,
                    }).ToList();
                    return new BaseResponse<List<CartItemDto>> { Message = "Product items retrieved successfully", IsSuccessful = true, Data = items };
                }
                return new BaseResponse<List<CartItemDto>> { Message = "Product Items not found", IsSuccessful = false, Data = new List<CartItemDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse< List <CartItemDto >> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = new List<CartItemDto>() };
            }
        }

        public async Task<BaseResponse<CartItemDto>> GetCartItem(Guid id)
        {
            try
            {
                var cartItem = await _cartItemRepository.GetCartItemAsync(id);
                if (cartItem != null)
                {
                    var item = new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        Price = cartItem.Price,
                        TotalPrice = cartItem.TotalPrice,
                        Quantity = cartItem.Quantity,
                    };
                    return new BaseResponse<CartItemDto> { Message = "Product item retrieved Successfully", IsSuccessful = true, Data = item };
                }
                return new BaseResponse<CartItemDto> { Message = "product item not found", IsSuccessful = false, Data = new CartItemDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CartItemDto> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = new CartItemDto() };
            }
        }

        public async Task<BaseResponse<bool>> UpdateCartItem(Guid id, UpdateCartItemDto request)
        {
            try
            {
                request.Id = id;
                var cartItem = await _cartItemRepository.GetCartItemAsync(id);
                if ( cartItem != null )
                {
                    cartItem.ProductId = request.Id;
                    cartItem.Price = request.Price;
                    cartItem.Quantity = request.Quantity;
                    cartItem.TotalPrice = request.TotalPrice;
                    cartItem.UpdateDate = DateTime.Now;
                    _dbContext.CartItems.Update(cartItem);
                    if(await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Product item updated successful", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> {Message ="Product item not found", IsSuccessful=false, Data = false};
                }
                return new BaseResponse<bool> { Message = "Product item not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = false };
            }
        }
    }
}
