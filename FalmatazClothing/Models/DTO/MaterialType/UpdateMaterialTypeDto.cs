using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.DTO.MaterialType
{
    public class UpdateMaterialTypeDto
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
