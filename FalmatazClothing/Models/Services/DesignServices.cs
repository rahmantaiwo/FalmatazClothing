using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.Design;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Repository;

namespace FalmatazClothing.Models.Services
{
    public class DesignServices : IDesignServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDesignRepository _designRepository;
        public DesignServices(ApplicationDbContext dbContext, IDesignRepository designRepository)
        {
            _dbContext = dbContext;
            _designRepository = designRepository;
        }

        public async Task<BaseResponse<bool>> CreateDesign(CreateDesignDto request)
        {
            try
            {
                var newDesign = new Design()
                {
                    Fabric = request.Fabric,
                    Style = request.Style,
                    Price = request.Price,
                    Image = request.Image,
                };
                await _dbContext.Designs.AddAsync(newDesign);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Design created successfully", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "Design creation failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<bool>> DeleteDesign(Guid id)
        {
            try
            {
                var design = await _designRepository.GetDesignAsync(id);
                if (design != null)
                {
                    _dbContext.Designs.Remove(design);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Design deleted successfully", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "Design not found", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "Design not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<List<DesignDto>>> GetAllDesigns()
        {
            try
            {
                var design = await _designRepository.GetAllDesignAsync();
                if (design.Count > 0 )
                {
                    var data = design.Select(X => new DesignDto
                    {
                        Id = X.Id,
                        Fabric = X.Fabric,
                        Style = X.Style,
                        Price = X.Price,
                        Image = X.Image,
                    }).ToList();
                    return new BaseResponse<List<DesignDto>> { Message = "Design retrieved successfully", IsSuccessful = true, Data = new List<DesignDto>() };
                }
                return new BaseResponse<List<DesignDto>> { Message = "No data found", IsSuccessful = false, Data = new List<DesignDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<DesignDto>> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = new List<DesignDto>() };
            }
        }

        public async Task<BaseResponse<DesignDto>> GetDesign(Guid id)
        {
            try
            {
                var design = await _designRepository.GetDesignAsync(id);
                if (design != null)
                {
                    var data = new DesignDto
                    {
                        Id = design.Id,
                        Fabric = design.Fabric,
                        Style = design.Style,
                        Price = design.Price,
                        Image = design.Image,
                    };
                    return new BaseResponse<DesignDto> { Message = "Design retrieved successfully", IsSuccessful = true, Data = new DesignDto() };
                }
                return new BaseResponse<DesignDto> { Message = "No data found", IsSuccessful = false, Data = new DesignDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<DesignDto> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = new DesignDto() };
            }
        }

        public async Task<BaseResponse<bool>> UpdateDesign(Guid id, UpdateDesignDto request)
        {
            try
            {
                request.Id = id;
                var design = await _designRepository.GetDesignAsync(id);
                if (design != null)
                {
                    design.Fabric = request.Fabric;
                    design.Style = request.Style;
                    design.Price = request.Price;
                    design.Image = request.Image;
                    _dbContext.Designs.Update(design);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Design updated successfully", IsSuccessful = true, Data = true };
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
