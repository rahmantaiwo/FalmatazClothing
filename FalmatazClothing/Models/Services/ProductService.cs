using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.Product;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;

namespace FalmatazClothing.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;

        public ProductService(ApplicationDbContext dbContext, IProductRepository productRepository, IImageService imageService)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _imageService = imageService;
        }

        public async Task<BaseResponse<bool>> CreateProduct(CreateProductDto request)
        {
            try
            {
                var newProduct = new Product()
                {
                    Style = request.Style,
                    MaterialTypeId = request.MaterialTypeId,
                    Stock = request.Stock,
                    Price = request.Price,
                };
                if (request.ImageProduct != null)
                {
                    var imagePaths = await _imageService.AddImagesAsync(request.ImageProduct);
                    if (imagePaths.Any())
                    {
                        newProduct.ImageProduct = string.Join(",", imagePaths);
                    }
                }
                await _dbContext.Products.AddAsync(newProduct);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Product created Succesfully", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "Product creation failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = false };
            }

        }

        public async Task<BaseResponse<bool>> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productRepository.GetProductAsync(id);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Product deleted successfuly", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "Product not found", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "Product not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<List<ProductDto>>> GetAllProducts()
        {
            try
            {
                var product = await _productRepository.GetAllProductAsync();
                if (product.Count > 0)
                {
                    var data = product.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Style = p.Style,
                        ImageProduct = p.ImageProduct,
                        MaterialTypeId = p.MaterialTypeId,
                        Stock = p.Stock,
                        Price = p.Price,
                        MaterialType = p.MaterialType.Name
                    }).ToList();
                    return new BaseResponse<List<ProductDto>> { Message = "Products retrieved successfull", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<List<ProductDto>> { Message = "Products not found", IsSuccessful = false, Data = new List<ProductDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ProductDto>> { Message = $"Error:{ex.Message}", IsSuccessful = false, Data = new List<ProductDto>() };
            }
        }

        public async Task<BaseResponse<ProductDto>> GetProduct(Guid id)
        {
            try
            {
                var product = await _productRepository.GetProductAsync(id);
                if (product != null)
                {
                    var data = new ProductDto
                    {
                        Id = product.Id,
                        Style = product.Style,
                        ImageProduct = product.ImageProduct,
                        Stock = product.Stock,
                        MaterialTypeId = product.MaterialTypeId,
                        Price = product.Price,  
                        MaterialType = product.MaterialType.Name
                    };
                    return new BaseResponse<ProductDto> { Message = "Product retrieved successful", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<ProductDto> { Message = "Product not found", IsSuccessful = false, Data = new ProductDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductDto> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = new ProductDto() };
            }
        }

        public async Task<BaseResponse<bool>> UpdateProduct(Guid id, UpdateProductDto request)
        {
            try
            {
                request.Id = id;
                var product = await _productRepository.GetProductAsync(id);
                if (product != null)
                {
                    product.ImageProduct = request.ImageProduct;
                    product.Style = request.Style; 
                    product.Stock = request.Stock;
                    product.MaterialTypeId = request.MaterialTypeId;
                    product.Price = request.Price;
                    product.UpdateDate = DateTime.Now;
                    _dbContext.Products.Update(product);
                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Product updated succcessfuly", IsSuccessful = true, Data = true };
                    }
                    return new BaseResponse<bool> { Message = "Update product failed", IsSuccessful = false, Data = false };
                }
                return new BaseResponse<bool> { Message = "Update product failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }
    }
}
