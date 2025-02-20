namespace FalmatazClothing.Entities
{
    public class CartItem : Auditability
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set;  }

        //public CartItem() 
        //{
        //    this.TotalPrice = Quantity * Price;
        //}
    }

}
