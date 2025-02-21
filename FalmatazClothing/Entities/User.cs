using FalmatazClothing.Enum;
using Microsoft.AspNetCore.Identity;

namespace FalmatazClothing.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public UserRole UserRole { get; set; }
        public Cart Cart { get; set; }
    }
}
