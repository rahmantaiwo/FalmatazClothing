using FalmatazClothing.Enum;

namespace FalmatazClothing.Models.DTO.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public ProductStyles Style { get; set; }
        public Guid MaterialTypeId { get; set; }
        public string MaterialType { get; set; }
        public string ImageProduct { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
