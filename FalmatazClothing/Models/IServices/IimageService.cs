namespace FalmatazClothing.Models.IServices
{
    public interface IImageService
    {
        //Task SaveFilesAsync(IFormFileCollection files);
        Task<List<string>> AddImagesAsync(IFormFileCollection files);
        //Task<List<byte[]>> ConvertFilesToBytesAsync(IFormFileCollection files);
    }
}
