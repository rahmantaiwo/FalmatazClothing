namespace FalmatazClothing.Entities
{
    public class CartItem : Auditability
    {
        public Guid ProductId { get; set; } 
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product? Product { get; set; }
        public Cart? Cart { get; set; } 
    }

}
