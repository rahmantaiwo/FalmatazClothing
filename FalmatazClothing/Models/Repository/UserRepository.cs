using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _identitydbContext;
        public UserRepository(ApplicationDbContext identitydbContext)
        {
            _identitydbContext = identitydbContext;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _identitydbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsyn(string email, string password)
        {
            return _identitydbContext.Users.FirstOrDefault(x => x.Email == email && x.PasswordHash == password);
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _identitydbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
