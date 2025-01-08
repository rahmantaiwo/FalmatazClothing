using FalmatazClothing.Models.DTO.MaterialType;
using FalmatazClothing.Models.DTO.Product;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all-productTypes")]
        public async Task<IActionResult> Products()
        {
            var result = await _productService.GetAllProducts();
            if (result != null)
            {
                return View(result.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> ProductDetail([FromRoute] Guid id)
        {
            var result = await _productService.GetProduct(id);
            return View(result.Data);
        }

        [HttpGet("create-product")]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto request)
        {
            var result = await _productService.CreateProduct(request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("MaterialTypes");
            }
            return RedirectToAction("CreateMaterialType");
        }


        [HttpGet("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id)
        {
            var result = await _productService.GetProduct(id);
            return View(result.Data);
        }


        [HttpPost("update-product/{id}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id, [FromForm] UpdateProductDto request)
        {
            var result = await _productService.UpdateProduct(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("ProductDetail", new { id = id });
            }
            return RedirectToAction("Products");
        }

        [HttpGet("delete-product/{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Products");
            }
            return RedirectToAction("DeleteProduct");
        }
    }
}
