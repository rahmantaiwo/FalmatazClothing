using AspNetCoreHero.ToastNotification.Abstractions;
using FalmatazClothing.Models.DTO.MaterialType;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class MaterialTypeController : Controller
    {
        private readonly IMaterialTypeService _materialTypeService;
        private readonly INotyfService _notyf;
        
        public MaterialTypeController(IMaterialTypeService materialTypeService, INotyfService notyf)
        {
            _materialTypeService = materialTypeService;
            _notyf = notyf;
        }

        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Customer")]
        [HttpGet("all-materialTypes")]
       public  async Task<IActionResult> MaterialTypes()
        {
            var result = await _materialTypeService.GetAllMaterialTypes();
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
        [HttpGet("materialType/{id}")]
        public async Task<IActionResult> MaterialTypeDetail([FromRoute] Guid id)
        { 
            var result = await _materialTypeService.GetMaterialType(id);
            return View(result.Data);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("create-materialType")]
        public async Task<IActionResult> CreateMaterialType()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("create-materialType")]
        public async Task<IActionResult> CreateDesign([FromForm] CreateMaterialTypeDto request)
        {
            TempData["NotificationMessage"] = "Form submitted successfully!";
            TempData["NotificationType"] = "success";
            var result = await _materialTypeService.CreateMaterialType(request);
            if (result.IsSuccessful)
            {
                _notyf.Success("Material created successful");
                return RedirectToAction("MaterialTypes");
            }
            _notyf.Error("Failed to create material");
            return RedirectToAction("CreateMaterialType");
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("update-materialType/{id}")]
        public async Task<IActionResult> UpdateMaterialType([FromRoute] Guid id)
        {
            var result = await _materialTypeService.GetMaterialType(id);
            return View(result.Data);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("update-materialType/{id}")]
        public async Task<IActionResult> UpdateMaterialTypeAsync([FromRoute] Guid id, [FromForm] UpdateMaterialTypeDto request)
        {

            //TempData["NotificationMessage"] = "Form submitted successfully!";
            //TempData["NotificationType"] = "success";
            var result = await _materialTypeService.UpdateMaterialType(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("MaterialTypeDetail", new { id = id });
            }
            return RedirectToAction("MaterialTypes");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("delete-materialType/{id}")]
        public async Task<IActionResult> DeletematerialTypeAsync([FromRoute] Guid id)
        {
            var result = await _materialTypeService.DeleteMaterialType(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("MaterialTypes");
            }
            return RedirectToAction("DeleteMaterialType");
        }
    }
}
