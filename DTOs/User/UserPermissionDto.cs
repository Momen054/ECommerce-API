using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.User
{
    public class UserPermissionDto
    {
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
    }
}
