using FalmatazClothing.Entities;
using FalmatazClothing.Models;
using FalmatazClothing.Models.DTO.MaterialType;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Repository;
using FalmatazClothing.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Services 
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly IImageService _imageService;

        public MaterialTypeService(ApplicationDbContext dbContext, IMaterialTypeRepository materialTypeRepository, IImageService imageService)
        {
            _dbContext = dbContext;
            _materialTypeRepository = materialTypeRepository;
            _imageService = imageService;
        }

        public async Task<BaseResponse<bool>> CreateMaterialType(CreateMaterialTypeDto request)
        {
            try
            {
                var newMaterialType = new MaterialType()
                {
                    Name = request.Name,
                };
                if (request.ImageUrl != null)
                {
                    var imagePaths = await _imageService.AddImagesAsync(request.ImageUrl);
                    if (imagePaths.Any())
                    {
                        newMaterialType.ImageUrl = string.Join(",", imagePaths);
                    }
                }
                await _dbContext.MaterialTypes.AddAsync(newMaterialType);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return new BaseResponse<bool> { Message = "Material created successfuly", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "Material not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<bool>> DeleteMaterialType(Guid Id)
        {
            try
            {
                var materrialType = await _materialTypeRepository.GetMaterialTypeAsync(Id);
                if (materrialType != null)
                {
                    _dbContext.MaterialTypes.Remove(materrialType);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Materials deleated successful", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "Materials deleated failed", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "Materials deleated failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"{ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<List<MaterialTypeDto>>> GetAllMaterialTypes()
        {
            try
            {
                var materialType = await _materialTypeRepository.GetAllMaterialTypeAsync();
                if (materialType.Count > 0)
                {
                    var data = materialType.Select(x => new MaterialTypeDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ImageUrl = x.ImageUrl,
                    }).ToList();
                    return new BaseResponse<List<MaterialTypeDto>> { Message = "Materials retrieved successful", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<List<MaterialTypeDto>> { Message = "Materials not found", IsSuccessful = false, Data = new List<MaterialTypeDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<MaterialTypeDto>> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = new List<MaterialTypeDto>() };
            }
        }

        public async Task<BaseResponse<MaterialTypeDto>> GetMaterialType(Guid Id)
        {
            try
            {
                var materialType = await _materialTypeRepository.GetMaterialTypeAsync(Id);
                if (materialType != null)
                {
                    var data = new MaterialTypeDto
                    {
                        Id = materialType.Id,
                        Name = materialType.Name,
                        ImageUrl = materialType.ImageUrl,
                    };
                    return new BaseResponse<MaterialTypeDto> { Message = "Material retrieved successful", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<MaterialTypeDto> { Message = "Material not found", IsSuccessful = false, Data = new MaterialTypeDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MaterialTypeDto> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = new MaterialTypeDto() };
            }
        }

        public async Task<BaseResponse<bool>> UpdateMaterialType(Guid id, UpdateMaterialTypeDto request)
        {
            try
            {
                request.Id = id;
                var materialType = await _materialTypeRepository.GetMaterialTypeAsync(id);
                if (materialType != null)
                {
                    materialType.Name = request.Name;
                    materialType.ImageUrl = request.ImageUrl;
                    _dbContext.MaterialTypes.Update(materialType);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Material updated successfully", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "Material updateda failed", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "Material updateda failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }
    }
}

