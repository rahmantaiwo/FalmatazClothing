using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
using FalmatazClothing.Models.DTO;
using FalmatazClothing.Models.DTO.User;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
namespace FalmatazClothing.Models.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _identityDbContext;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(ApplicationDbContext identityDbContext, IUserRepository userRepository, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _identityDbContext = identityDbContext;
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<BaseResponse<bool>> CreateUser(CreateUserDto request)
        {
            try
            {
       return new BaseResponse<bool> { Message = $"Role {request.Role} does not exist.", IsSuccessful = false };
                var newUser = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = request.UserName,
                    PhoneNumber = request.PhoneNumber,
                    UserRole = request.Role ?? UserRole.Customer,
                    CreateDate = DateTime.Now
                };
                var addUser = await _userManager.CreateAsync(newUser, request.Password);
                if(!addUser.Succeeded)
                    return new BaseResponse<bool> { Message = addUser.Errors.First().Description };

                var addRoleResult = await _userManager.AddToRoleAsync(newUser, newUser.UserRole.ToString());
                if(!addRoleResult.Succeeded)
                {
                    var errors = string.Join(" ,", addRoleResult.Errors.Select(e => e.Description));
                    return new BaseResponse<bool> { Message = $"Role assignmet failed:{errors}", IsSuccessful = false };
                }

                return new BaseResponse<bool> { Message = "Uder&Role created successful", IsSuccessful = true, Data = true };
            }
            catch (Exception ex) 
            {
                return new BaseResponse<bool> { Message = $"An error occurerd:{ex.Message}", IsSuccessful = false };
            }
        }

        public async Task<BaseResponse<bool>> DeleteUser(string id)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(id);
                if(user != null)
                {
                    _identityDbContext.Users.Remove(user);
                    if(await _identityDbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "User profile deleted successfullly", IsSuccessful = true, Data = true };

                    }
                }
                return new BaseResponse<bool> { Message = "User not found", IsSuccessful = false, Data = false};
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false};
            }
            
        }

        public async Task<BaseResponse<List<UserDto>>> GetAllUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                var userDto = new List<UserDto>();
                foreach(var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userDto.Add(new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber
                    });
                }
                return new BaseResponse<List<UserDto>> { Message = "Users profile  retrieved successfully", IsSuccessful = true, Data = userDto };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserDto>> { Message = $"Error: {ex.Message}", IsSuccessful = false };
            }
        }

        public async Task<BaseResponse<UserDto>> GetUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if(user !=  null)
                {
                    var roles = await _userManager.FindByIdAsync(id);
                    var data = new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber
                    };
                    return new BaseResponse<UserDto> { Message = "User profile retrieved successful", IsSuccessful = true, Data = data };
                }
                return new BaseResponse<UserDto> { Message = "User profile not found", IsSuccessful = false, Data = new UserDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserDto> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = new UserDto() };
            }
        }

        public async Task<User?> GetUserNameAsync(string name)
        {
            var user = await _identityDbContext.Users
                .Where(x => x.UserName == name)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<Status> LoginAsync(LoginModel model)
        {
            var status = new Status();
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (!await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        status.StatusCode = 0;
                        status.Message = "Invalid Password or Username";
                        return status;
                    }

                    var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    if (signInResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        var authClaims = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, user.Email),
                 };

                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }

                        if (System.Enum.TryParse<UserRole>(userRoles.FirstOrDefault(), true, out var parsedRole))
                        {
                            status.Role = (UserRole?)parsedRole;
                        }
                        else
                        {
                            status.Role = null;
                        }

                        status.StatusCode = 1;
                        status.Success = true;
                        status.Message = "Logged in successfully";
                    }
                    else if (signInResult.IsLockedOut)
                    {
                        status.StatusCode = 0;
                        status.Message = "User is locked out";
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error on logging in";
                    }

                    return status;
                }
                status.StatusCode = 0;
                status.Message = "Invalid login details";
                return status;
            }
            catch (Exception ex)
            {
                status.StatusCode = 0;
                status.Message = "Error occurred while processing your request";
                return status;
            }
        }

        public async Task<BaseResponse<bool>> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return new BaseResponse<bool> { Message = "Sign out successfully", IsSuccessful = true };
        }

        public async Task<BaseResponse<bool>> UpdateUser(string id, UpdateUserDto request)
        {
            try
            {
                var userExist =await _userRepository.GetUserAsync(id);
                if (userExist == null)
                {
                    return new BaseResponse<bool> { Message = "User profile not found", IsSuccessful = false, Data = false };
                }
                userExist.FirstName = request.FirstName;
                userExist.LastName = request.LastName;
                userExist.Email = request.Email;
                userExist.UserName = request.UserName;
                _identityDbContext.Users.Update(userExist);

                if (await _identityDbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "User profile updated successfully", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "User profile update failed", IsSuccessful = false, Data = false };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
            }
        }
    }
}
