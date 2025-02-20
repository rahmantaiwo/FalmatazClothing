using FalmatazClothing.Models.DTO.Product;

namespace FalmatazClothing.Models.IServices
{
    public interface IProductService
    {
        //Task<BaseResponse<bool>> CheckIfMaterialTypeExist(Guid Id);
        Task<BaseResponse<bool>> CreateProduct(CreateProductDto request);
        Task<BaseResponse<List<ProductDto>>> GetAllProducts();
        Task<BaseResponse<ProductDto>> GetProduct(Guid id);
        Task<BaseResponse<bool>> UpdateProduct(Guid id, UpdateProductDto request);
        Task<BaseResponse<bool>> DeleteProduct(Guid id);
    }
}
