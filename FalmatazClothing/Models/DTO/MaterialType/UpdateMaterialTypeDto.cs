using FalmatazClothing.Entities;
using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.MaterialType
{
    public class UpdateMaterialTypeDto
    {
        [Required(ErrorMessage = "Guid is required")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string ImageUrl { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
