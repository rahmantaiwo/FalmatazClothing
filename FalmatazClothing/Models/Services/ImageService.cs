using FalmatazClothing.Entities;
using FalmatazClothing.Models.IServices;

namespace FalmatazClothing.Models.Services
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment _environment;
        private readonly string _imageFolderPath;
        public ImageService(ApplicationDbContext _dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
            _imageFolderPath = Path.Combine(environment.ContentRootPath, "wwwroot", "Images");
        }

        //public Task<List<byte[]>> ConvertFilesToBytesAsync(IFormFileCollection files)
        //{
        //    var byteList = new List<byte[]>();
        //    foreach (var file in files)
        //    {
        //        using var memoryStream = new MemoryStream();
        //        await file.CopyToAsync(memoryStream);
        //        byteList.Add(memoryStream.ToArray());
        //    }
        //    return byteList;
        //}

        public async Task<List<string>>AddImagesAsync(IFormFileCollection files)
        {
            var imagePaths = new List<string>(); 
            //var filePath = Path.Combine(_environment.WebRootPath, _imageFolderPath);
            //Directory.CreateDirectory(_imageFolderPath);

            foreach (var file  in files)
            {
                if (file.Length > 0)
                {
                    var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(_imageFolderPath, fileName);
                    Directory.CreateDirectory(_imageFolderPath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    imagePaths.Add("Images/" + fileName);
                }
            }
            return imagePaths;
        }
    }
}
