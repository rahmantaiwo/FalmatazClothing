using FalmatazClothing.Models.DTO.Inventory;

namespace FalmatazClothing.Models.IServices
{
    public interface IImageService
    {
        
        Task<List<string>> AddImagesAsync(IFormFileCollection files);
    }
}
