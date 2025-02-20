using FalmatazClothing.Entities;
using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.MaterialType
{
    public class CreateMaterialTypeDto
    {
        [Required(ErrorMessage ="Guid is required")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public IFormFileCollection ImageUrl { get; set; }
    }
}
