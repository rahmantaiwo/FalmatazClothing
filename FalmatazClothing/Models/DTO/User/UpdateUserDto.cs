using FalmatazClothing.Enum;
using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pasqord is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
