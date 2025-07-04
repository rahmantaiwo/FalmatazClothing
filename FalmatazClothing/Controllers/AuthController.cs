﻿using AspNetCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
using FalmatazClothing.Models.DTO;
using FalmatazClothing.Models.DTO.User;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FalmatazClothing.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly INotyfService _notyf;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IUserService userService, INotyfService notyf)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {

                var ServiceResult = await _userService.LoginAsync(model);

                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "user not found");
                    return View(model);
                }

                var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
                if (signInResult.Succeeded)

                {

                    var roles = await _userManager.GetRolesAsync(user);

                    _notyf.Success("User loggedin successfuly");

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Store");
                    }
                }
                return View(model);
            }
            
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model); // ✅ Return the login view if login fails
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("register-user")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register(CreateUserDto request)
        {
            TempData["NotificationMessage"] = "Account created successfully!";
            TempData["NotificationType"] = "success";
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUser(request);

                if (result.IsSuccessful)
                {
                    _notyf.Success("Account created successfully");
                    return RedirectToAction("Login", "Auth");
                }
                _notyf.Error("Account creation failed");
                TempData["msg"] = result.Message;
            }

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var response = await _userService.SignOutAsync();

            if (response.IsSuccessful)
            {
                return RedirectToAction("Login", "Auth");
            }

            return RedirectToAction("Login", "Auth");
        }


        [HttpGet("users")]
        public async Task<IActionResult> Users()
        {
            var result = await _userService.GetAllUsers();

            if (result.IsSuccessful)
            {
                return View(result.Data);
            }

            TempData["msg"] = result.Message;
            return View(result.Data);
        }
    }
}
