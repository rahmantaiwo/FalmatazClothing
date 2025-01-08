namespace FalmatazClothing.Models.DTO.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public Guid MaterialTypeId { get; set; }
        public string MaterialType { get; set; }
        public IFormFileCollection ImageProduct { get; set; }
        public decimal Price { get; set; }
    }
}
