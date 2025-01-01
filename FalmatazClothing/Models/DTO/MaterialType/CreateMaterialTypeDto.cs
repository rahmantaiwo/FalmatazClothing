using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.DTO.MaterialType
{
    public class CreateMaterialTypeDto
    {
        public string Name { get; set; }
        public IFormFileCollection ImageUrl { get; set; }
    }
}
