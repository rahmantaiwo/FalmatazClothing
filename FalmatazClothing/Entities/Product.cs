using FalmatazClothing.Enum;

namespace FalmatazClothing.Entities
{
    public class Product : Auditability
    {
        public ProductStyles Style { get; set; }
        public Guid MaterialTypeId {  get; set; }
        public MaterialType MaterialType { get; set; }
        public string ImageProduct { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
