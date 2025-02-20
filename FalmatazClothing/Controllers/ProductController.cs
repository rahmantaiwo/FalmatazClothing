using AspNetCoreHero.ToastNotification.Abstractions;
using FalmatazClothing.Models.DTO.MaterialType;
using FalmatazClothing.Models.DTO.Product;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FalmatazClothing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMaterialTypeService _materialTypeService;
        private readonly INotyfService _notyf;

        public ProductController(IProductService productService, IMaterialTypeService materialTypeService, INotyfService notyf)
        {
            _productService = productService;
            _materialTypeService = materialTypeService;
            _notyf = notyf;
        }
        //[Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]
        [HttpGet("product/{id}")]
        public async Task<IActionResult> ProductDetail([FromRoute] Guid id)
        {
            var result = await _productService.GetProduct(id);

            return View(result.Data);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("create-product")]
        public async Task<IActionResult> CreateProduct()
        {
            var materialTypes = await _materialTypeService.GetAllMaterialTypes();

            ViewData["selectMaterialTypes"] = new SelectList(materialTypes.Data, "Id", "Name");
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto request)
        {

            TempData["NotificationMessage"] = "Form submitted successfully!";
            TempData["NotificationType"] = "success";
            var result = await _productService.CreateProduct(request);
            if (result.IsSuccessful)
            {
                _notyf.Success("Style created successful");
                return RedirectToAction("Products");
            }
            _notyf.Error("Failed to create style");
            return RedirectToAction("CreateMaterialType");
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id)
        {
            var materialTypes = await _materialTypeService.GetAllMaterialTypes();
            ViewData["selectMaterialTypes"] = new SelectList(materialTypes.Data, "Id", "Name");

            var result = await _productService.GetProduct(id);
            return View(result.Data);
        }

        //[Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]
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
