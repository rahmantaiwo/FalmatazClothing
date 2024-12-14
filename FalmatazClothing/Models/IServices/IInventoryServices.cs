using FalmatazClothing.Models.DTO.Inventory;

namespace FalmatazClothing.Models.IServices
{
    public interface IInventoryServices
    {
        Task<BaseResponse<bool>> CreateInventory(CreateInventoryDto request);
        Task<BaseResponse<bool>> UpdateInventory(Guid id, InventoryDto request);
        Task<BaseResponse<bool>> DeleteInventory(Guid id);
        Task<BaseResponse<InventoryDto>> GetInventory(Guid id);
        Task<BaseResponse<List<InventoryDto>>> GetAllInventory();

    }
}
