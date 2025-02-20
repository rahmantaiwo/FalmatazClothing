using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO;
using FalmatazClothing.Models.DTO.User;

namespace FalmatazClothing.Models.IServices
{
    public interface IUserService
    {
        Task<BaseResponse<bool>> CreateUser(CreateUserDto request);
        Task<BaseResponse<bool>> UpdateUser(string id, UpdateUserDto request);
        Task<BaseResponse<bool>> DeleteUser(string id);
        Task<BaseResponse<UserDto>> GetUser(string id);
        Task<BaseResponse<List<UserDto>>> GetAllUsers();
        Task<BaseResponse<bool>> SignOutAsync();
        Task<Status> LoginAsync(LoginModel login);
        Task<User?> GetUserNameAsync(string name);

    }
}
