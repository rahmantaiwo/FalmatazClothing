namespace FalmatazClothing.Entities
{
    public class MaterialType : Auditability
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Product> Products { get; set;} = new List<Product>();
    }
}
