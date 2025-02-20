using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.IRepository
{
    public interface IUserRepository
    {
            Task<List<User>> GetAllUserAsync();
            Task<User> GetUserAsync(string Id);
            Task<User> GetUserAsyn(string Email, string Password);
    }
}
