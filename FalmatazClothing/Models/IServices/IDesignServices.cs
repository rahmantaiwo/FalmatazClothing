using FalmatazClothing.Models.DTO.Design;

namespace FalmatazClothing.Models.IServices
{
    public interface IDesignServices
    {
        Task<BaseResponse<bool>> CreateDesign(CreateDesignDto request);
        Task<BaseResponse<bool>> UpdateDesign(Guid id, UpdateDesignDto request);
        Task<BaseResponse<bool>> DeleteDesign(Guid id);
        Task<BaseResponse<DesignDto>> GetDesign(Guid id);
        Task<BaseResponse<List<DesignDto>>> GetAllDesigns();
    }
}
