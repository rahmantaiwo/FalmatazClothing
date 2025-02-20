using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.CartItem;
using FalmatazClothing.Models.DTO.Product;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FalmatazClothing.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICarItemService _carItemService;
        private readonly IProductService _productService;
        public CartItemController(ICarItemService carItemService, IProductService productService)
        {
            _carItemService = carItemService;
            _productService = productService;
        }

        [HttpGet("all-cartItemTypes")]
        public async Task<IActionResult> CartItems()
        {
            var CartItems = await _carItemService.GetAllCartItems();
            foreach (var item in CartItems.Data)
            {
                 var product =await _productService.GetProduct(item.ProductId);
                if(product != null)
                {
                    item.ProductName = product.Data.Style.ToString();
                    item.ProductImage = product.Data.ImageProduct;
                }
            }
            return View(CartItems.Data);
        }
        [HttpGet("cartItems/{id}")]
        public async Task<IActionResult> CartItemDetail([FromRoute] Guid id)
        {
            var result = await _carItemService.GetCartItem(id);
            return View(result.Data);
        }
        [HttpGet("create-cartItem")]
        public async Task<IActionResult> CreateCartItem()
        {
            var products = await _productService.GetAllProducts();

            if(products != null && products.Data.Any())
            {
                ViewData["selectProducts"] = products.Data.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Style.ToString(),
                    Group = new SelectListGroup { Name = p.Price.ToString() }  // Pass price through group
                }).ToList();

                ViewData["productData"] = products.Data;  // ✅ Store full product details
            }
            else
            {
                ViewData["selectProducts"] = new List<SelectListItem>();
                ViewData["productData"] = new List<ProductDto>();
            }
            return View();
        }
        [HttpGet("get-product-details/{productId}")]
        public async Task<JsonResult>GetProductDetails(Guid productId)
        {
            var product = await _productService.GetProduct(productId);
            if(product == null)
            {
                return Json(new { success = false, message = "product not found" });
            }
            return Json(new
            {
                success = true,
                price = product.Data.Price,
                imageProduct = product.Data.ImageProduct
            });
        }
        [HttpPost("create-CartItem")]
        public async Task<IActionResult> CreateCartItem([FromRoute] CreateCartItemDto request)
        {
            var result = await _carItemService.CreateCartItem(request);
            if(result.IsSuccessful)
            {
                return RedirectToAction("CartItems");
            }
            return RedirectToAction("CreateCartItem");
        }
        [HttpGet("update-CartItem/{id}")]
        public async Task<IActionResult> UpadateCartItem([FromRoute] Guid id)
        {
            var products = await _productService.GetAllProducts();
            ViewData["selectProducts"] = products.Data.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Style.ToString()
            }).ToList();
            return View(products);
        }
        [HttpPost("update-CartItem/{id}")]
        public async Task<IActionResult> UpdateCartItemAsync([FromRoute] Guid id, [FromForm] UpdateCartItemDto request)
        {
            var result = await _carItemService.UpdateCartItem(id, request);
            if(result.IsSuccessful)
            {
                return RedirectToAction("CartItemDetail", new { id });
            }
            return RedirectToAction("CartItems");
        }
        [HttpPost("delete-CartItem/{id}")]
        public async Task<IActionResult> DeleteCartItem([FromRoute] Guid id)
        {
            var result = await _carItemService.DeleteCartItem(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("CartItems");
            }
            return RedirectToAction("CartItemDetail", new { id });
        }
        [HttpGet("checkout")]
        public IActionResult ProceedToCheckout()
        {
            return RedirectToAction("Checkout", "Cart");
        }
    }
}
