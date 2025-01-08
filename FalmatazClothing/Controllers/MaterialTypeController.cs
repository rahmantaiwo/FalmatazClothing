using FalmatazClothing.Models.DTO.MaterialType;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class MaterialTypeController : Controller
    {
        private readonly IMaterialTypeService _materialTypeService;
        
        public MaterialTypeController(IMaterialTypeService materialTypeService)
        {
            _materialTypeService = materialTypeService;
        }

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

        [HttpGet("materialType/{id}")]
        public async Task<IActionResult> MaterialTypeDetail([FromRoute] Guid id)
        { 
            var result = await _materialTypeService.GetMaterialType(id);
            return View(result.Data);
        }

        [HttpGet("create-materialType")]
        public async Task<IActionResult> CreateMaterialType()
        {
            return View();
        }

        [HttpPost("create-materialType")]
        public async Task<IActionResult> CreateDesign([FromForm] CreateMaterialTypeDto request)
        {
            var result = await _materialTypeService.CreateMaterialType(request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("MaterialTypes");
            }
            return RedirectToAction("CreateMaterialType");
        }


        [HttpGet("update-materialType/{id}")]
        public async Task<IActionResult> UpdateMaterialType([FromRoute] Guid id)
        {
            var result = await _materialTypeService.GetMaterialType(id);
            return View(result.Data);
        }


        [HttpPost("update-materialType/{id}")]
        public async Task<IActionResult> UpdateMaterialTypeAsync([FromRoute] Guid id, [FromForm] UpdateMaterialTypeDto request)
        {
            var result = await _materialTypeService.UpdateMaterialType(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("MaterialTypeDetail", new { id = id });
            }
            return RedirectToAction("MaterialTypes");
        }

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
