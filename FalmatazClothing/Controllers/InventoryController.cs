using FalmatazClothing.Models.DTO.Inventory;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryServices _inventoryServices;

        public InventoryController(IInventoryServices inventoryServices)
        {
            _inventoryServices = inventoryServices;
        }
        [HttpGet("all-inventories")]
        public async Task<IActionResult> Inventories()
        {
            var result = await _inventoryServices.GetAllInventory();
            if (result != null)
            {
                return View(result.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        [HttpGet("inventory/{id}")]
        public async Task<IActionResult> InventoryDetail([FromRoute] Guid id)
        {
            var result = await _inventoryServices.GetInventory(id);
            return View(result.Data);
        }

        [HttpGet("create-inventory")]
        public async Task<IActionResult> CreateInventory()
        {
            return View();
        }


        [HttpPost("create-inventory")]
        public async Task<IActionResult> CreateInventory([FromForm] CreateInventoryDto request)
        {
            var result = await _inventoryServices.CreateInventory(request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Inventories");
            }
            return RedirectToAction("CreateInventory");
        }


        [HttpGet("update-inventory/{id}")]
        public async Task<IActionResult> UpdateInventory([FromRoute] Guid id)
        {
            var result = await _inventoryServices.GetInventory(id);
            return View(result.Data);
        }


        [HttpPost("update-inventory/{id}")]
        public async Task<IActionResult> UpdateInventoryAsync([FromRoute] Guid id, [FromForm] InventoryDto request)
        {
            var result = await _inventoryServices.UpdateInventory(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("InventoryDetail", new { id = id });
            }
            return RedirectToAction("Inventories");
        }

        [HttpGet("delete-inventory/{id}")]
        public async Task<IActionResult> DeleteInventoryAsync([FromRoute] Guid id)
        {
            var result = await _inventoryServices.DeleteInventory(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Inventories");
            }
            return RedirectToAction("Inventories");
        }
    }
}

