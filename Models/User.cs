using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce.Models;

public partial class User
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

    public virtual Cart? Cart { get; set; }

    public List<UserRoles> userRoles { get; set; } = [];

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

}
