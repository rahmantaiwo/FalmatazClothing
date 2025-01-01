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
        public async 
    }
}
