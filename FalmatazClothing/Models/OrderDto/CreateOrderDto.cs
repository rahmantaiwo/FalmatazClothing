using FalmatazClothing.Entities;

namespace FalmatazClothing.Models
{
    public class CreateOrderDto
    {
        public Guid Id { get; set; }
        public Guid DesignId { get; set; }
        public Design Design { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
