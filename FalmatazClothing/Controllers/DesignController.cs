using FalmatazClothing.Models.DTO.Design;
using FalmatazClothing.Models.DTO.Inventory;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class DesignController : Controller
    {
        private readonly IDesignServices _designServices;

        public DesignController(IDesignServices designServices)
        {
            _designServices = designServices;
        }
        [HttpGet("all-designs")]
        public async Task<IActionResult> Designs()
        {
            var result = await _designServices.GetAllDesigns();
            if (result != null)
            {
                return View(result.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        [HttpGet("design/{id}")]
        public async Task<IActionResult> DesignDetail([FromRoute] Guid id)
        {
            var result = await _designServices.GetDesign(id);
            return View(result.Data);
        }

        [HttpGet("create-design")]
        public async Task<IActionResult> CreateDesign()
        {
            return View();
        }


        [HttpPost("create-design")]
        public async Task<IActionResult> CreateDesign([FromForm] CreateDesignDto request)
        {
            var result = await _designServices.CreateDesign(request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Designs");
            }
            return RedirectToAction("CreateDesign");
        }


        [HttpGet("update-design/{id}")]
        public async Task<IActionResult> UpdateInventory([FromRoute] Guid id)
        {
            var result = await _designServices.GetDesign(id);
            return View(result.Data);
        }


        [HttpPost("update-design/{id}")]
        public async Task<IActionResult> UpdateDesignAsync([FromRoute] Guid id, [FromForm] UpdateDesignDto request)
        {
            var result = await _designServices.UpdateDesign(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("DesignDetail", new { id = id });
            }
            return RedirectToAction("Designs");
        }

        [HttpGet("delete-design/{id}")]
        public async Task<IActionResult> DeleteMeasurementAsync([FromRoute] Guid id)
        {
            var result = await _designServices.DeleteDesign(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Designs");
            }
            return RedirectToAction("DeleteDesign");
        }
    }
}
