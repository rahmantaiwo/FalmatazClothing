namespace FalmatazClothing.Models.DTO.Inventory
{
    public class UpdateInventory
    {
        public Guid Id { get; set; }    
        public string Fabric { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageFileName { get; set; }
    }
}
