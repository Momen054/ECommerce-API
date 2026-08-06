using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
