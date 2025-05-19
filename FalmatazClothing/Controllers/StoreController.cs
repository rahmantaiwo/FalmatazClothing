using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.Product;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductService _productService;
        public StoreController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllProducts();
            if (!response.IsSuccessful)
            {
                //ViewData["Message"] = response.Message;
                ViewBag.ErrorMessage = response.Message;
                return View(new List<ProductDto>());
            }
            return View(response.Data);
        }
    }
}
