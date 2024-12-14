namespace FalmatazClothing.Models.DTO.Design
{
    public class UpdateDesignDto
    {
        public Guid Id { get; set; }
        public string Fabric { get; set; }
        public string Style { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
