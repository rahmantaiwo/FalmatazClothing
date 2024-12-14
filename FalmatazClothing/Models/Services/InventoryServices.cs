using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.Inventory;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Repository;

namespace FalmatazClothing.Models.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IImageService _imageService;
        public InventoryServices(ApplicationDbContext dbContext, IInventoryRepository inventoryRepository, IImageService imageService)
        {
            _dbContext = dbContext;
            _inventoryRepository = inventoryRepository;
            _imageService = imageService;
        }

        //private string SaveImageToFolder(IFormFile imageFile)
        //{
        //    var imagesFolder = Path.Combine(_environment.WebRootPath, "images");
        //    Directory.CreateDirectory(imagesFolder);

        //    var filePath = Path.Combine(imagesFolder, imageFile.FileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        imageFile.CopyTo(stream);
        //    }
        //    return filePath;
        //}

        public async Task<BaseResponse<bool>> CreateInventory(CreateInventoryDto request)
        {
            try
            {

                //create  new inventory object
                var newInventory = new Inventory()
                {
                    Fabric = request.Fabric,
                    Quantity = request.Quantity,
                    Price = request.Price

                };
                if (request.ImageFileName != null)
                {
                    var imagePaths = await _imageService.AddImagesAsync(request.ImageFileName);

                    if (imagePaths.Any())
                    {
                        newInventory.ImageFileName = string.Join(";", imagePaths);
                    }
                }
                await _dbContext.Inventories.AddAsync(newInventory);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return new BaseResponse<bool> { Message = "Fabric selected successfully", IsSuccessful = true, Data = true };

                }
                return new BaseResponse<bool> { Message = "Fabric not found", IsSuccessful = false, Data = false };

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        //public async Task<BaseResponse<bool>> UploadInventoryImageAsync(Guid inventoryId, IFormFile file)
        //{
        //    try
        //    {
        //        if (file == null || file.Length == 0)
        //            return new BaseResponse<bool> { Message = "Invalid file", IsSuccessful = false, Data = false };

        //        var inventory = await _inventoryRepository.GetInventoryAsync(inventoryId);
        //        if (inventory == null)
        //            return new BaseResponse<bool> { Message = "Inventory not found", IsSuccessful = false, Data = false };

        //        // Validate file type
        //        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        //        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        //        if (!allowedExtensions.Contains(fileExtension))
        //            return new BaseResponse<bool> { Message = "Unsupported file type", IsSuccessful = false, Data = false };

        //        // Save the file to a local directory
        //        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        //        Directory.CreateDirectory(uploadsFolder); // Ensure directory exists
        //        var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
        //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }

        //        // Update the inventory with the new image file path
        //        inventory.ImageFileName = $"/uploads/{uniqueFileName}";
        //        _dbContext.Inventories.Update(inventory);

        //        if (await _dbContext.SaveChangesAsync() > 0)
        //        {
        //            return new BaseResponse<bool> { Message = "Image uploaded successfully", IsSuccessful = true, Data = true };
        //        }

        //        return new BaseResponse<bool> { Message = "Failed to save image", IsSuccessful = false, Data = false };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
        //    }
        //}


        public async Task<BaseResponse<bool>> DeleteInventory(Guid id)
        {
            try
            {
                var inventory = await _inventoryRepository.GetInventoryAsync(id);
                if (inventory != null)
                {
                    _dbContext.Inventories.Remove(inventory);

                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Fabric deleated successfully", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "Fabric not found", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "Fabric not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }


        public async Task<BaseResponse<List<InventoryDto>>> GetAllInventory()
        {
            try
            {
                var inventory = await _inventoryRepository.GetAllInventoryAsync();
                if (inventory.Count > 0)
                {
                    var data = inventory.Select(x => new InventoryDto
                    {
                        Id = x.Id,
                        Fabric = x.Fabric,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        ImageFileName = x.ImageFileName,
                    }).ToList();
                    return new BaseResponse<List<InventoryDto>> { Message = "Fabric retrieved successfully", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<List<InventoryDto>> { Message = "No data found", IsSuccessful = false, Data = new List<InventoryDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<InventoryDto>> { Message = $"Erroe: {ex.Message}", IsSuccessful = false, Data = new List<InventoryDto>() };
            }
        }




        public async Task<BaseResponse<InventoryDto>> GetInventory(Guid id)
        {
            try
            {
                var inventory = await _inventoryRepository.GetInventoryAsync(id);
                if (inventory != null)
                {
                    var data = new InventoryDto()
                    {
                        Id = id,
                        Fabric = inventory.Fabric,
                        Quantity = inventory.Quantity,
                        Price = inventory.Price,
                        ImageFileName = inventory.ImageFileName,
                    };
                    return new BaseResponse<InventoryDto> { Message = "Fabric retrieved succesfully", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<InventoryDto> { Message = "No record found", IsSuccessful = false, Data = new InventoryDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<InventoryDto> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = new InventoryDto() };
            }
        }
        public async Task<BaseResponse<bool>> UpdateInventory(Guid id, InventoryDto request)
        {
            try
            {
                request.Id = id;
                var inventory = await _inventoryRepository.GetInventoryAsync(id);
                if (inventory != null)
                {
                    inventory.Fabric = request.Fabric;
                    inventory.Quantity = request.Quantity;
                    inventory.Price = request.Price;
                    inventory.ImageFileName = request.ImageFileName;
                    _dbContext.Inventories.Update(inventory);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Fabric updated successfully", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "No record found", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "No record found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = false };
            }
        }
    }
}

