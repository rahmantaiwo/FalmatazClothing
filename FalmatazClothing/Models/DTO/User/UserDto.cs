﻿using FalmatazClothing.Enum;

namespace FalmatazClothing.Models.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
