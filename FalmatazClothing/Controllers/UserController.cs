using FalmatazClothing.Models.DTO.User;
using FalmatazClothing.Models.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("all-users")]
        public async Task<IActionResult> UsersAsync()
        {
            var result = await _userService.GetAllUsers();
            return View(result.Data);
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> UserDetailAsync([FromRoute] string id)
        {
            var result = await _userService.GetUser(id);
            return View(result.Data);
        }
        [HttpGet("create-user")]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDto request)
        {

            var result = await _userService.CreateUser(request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("User");
            }
            return RedirectToAction("User");
        }

        [HttpGet("update-user/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] string id)
        {
            var result = await _userService.GetUser(id);
            return View(result.Data);
        }

        [HttpPost("update-user/{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] string id, [FromForm] UpdateUserDto request)
        {
            var result = await _userService.UpdateUser(id, request);
            if (result.IsSuccessful)
            {
                return RedirectToAction("UserDetail", new { id = id });
            }
            return RedirectToAction("Users");
        }

        [HttpGet("delete-feedCategory/{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string id)
        {
            var result = await _userService.DeleteUser(id);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Users");
            }
            return RedirectToAction("DeleteUser");
        }
    }
}
