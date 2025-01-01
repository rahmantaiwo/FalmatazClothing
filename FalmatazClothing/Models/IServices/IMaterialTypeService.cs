using FalmatazClothing.Models.DTO.MaterialType;

namespace FalmatazClothing.Models.IServices
{
    public interface IMaterialTypeService
    {
        Task<BaseResponse<bool>> CreateMaterialType(CreateMaterialTypeDto request);
        Task<BaseResponse<MaterialTypeDto>> GetMaterialType(Guid Id);
        Task<BaseResponse<List<MaterialTypeDto>>> GetAllMaterialTypes();
        Task<BaseResponse<bool>> UpdateMaterialType(Guid Id, UpdateMaterialTypeDto request);
        Task<BaseResponse<bool>> DeleteMaterialType(Guid Id);
    }
}
