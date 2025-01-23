using FalmatazClothing.Enum;
using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.Product
{
    public class CreateProductDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required")]
        public ProductStyles Style { get; set; }
        [Required(ErrorMessage = "MaterialTypeId is required")]
        public Guid MaterialTypeId { get; set; }
        [Required(ErrorMessage = "MaterialType is required")]
        public string? MaterialType { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public IFormFileCollection ImageProduct { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
