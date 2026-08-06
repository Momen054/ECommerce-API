using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        public DateTime? CreatesAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
